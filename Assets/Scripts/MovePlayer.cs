using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour {
	// Floats
	public float maxSpeed;
	public float moveForce = 365f;
	public float jumpForce = 1f;
	public float dashForce;
	public float dashDelay = 2f;
	// Booleans
	public bool estaNoSolo;
	public bool canJump = true;
	public bool canDoubleJump = true;
	public bool canDash = true;
	public bool isAlive = true;
	public bool faceRight = true;
	
	public Transform testSolo;

	//Definitions
	public Rigidbody2D rd2;
	public Animator anim;
	public int id = 0;
    public int deaths = 0;

	//Strings & References
	public string horizontalCtrl;
	public string jump ;
	public string dash ;

    private float contPassos = 1f;

	void Start () {
		rd2 = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
	}
	 
	void Update () {
		/// =========================== Movimentação ===============================

		/// =========================== Pulo ================================
		estaNoSolo = Physics2D.OverlapCircle (testSolo.transform.position, 0.1f, 1 << LayerMask.NameToLayer ("Platform"));
        anim.SetBool("ground", estaNoSolo);
        handleHorizontalMovimentation ();
		handleJumpMovimentation();

		// =================== Dash =========================
		handleDashMovimentation();
		//identifyLive ();
		
	}

	//Handles Horizontal input and moves player
	public void handleHorizontalMovimentation(){
		float moveHorizontal = Input.GetAxisRaw (horizontalCtrl);
		anim.SetFloat("move", Mathf.Abs(moveHorizontal));

		if (moveHorizontal < 0 && !faceRight) {
			Flip ();
		} 
		else if (moveHorizontal > 0 && faceRight){
			Flip ();
		}

        if (moveHorizontal > 0) {
            if (contPassos >= 0.2f)
            {
                AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().passos, transform.position);
                contPassos = 0f;
            }
            else {
                contPassos += Time.deltaTime;
            }
            transform.Translate(maxSpeed * Time.deltaTime, 0, 0);
		}

		if (moveHorizontal < 0) {
            if (contPassos >= 0.2f)
            {
                AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().passos, transform.position);
                contPassos = 0f;
            }
            else {
                contPassos += Time.deltaTime;
            }
            transform.Translate (-maxSpeed * Time.deltaTime, 0, 0);
		}
			
	}

	// Handles Jump when input is received
	public void handleJumpMovimentation(){
		if (estaNoSolo)
			canJump = true;
		
		if (Input.GetButtonDown (jump)) {
			if (canJump) {
                //anim.Play("Blend Tree JUMP");
				AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().jump, transform.position);
				rd2.velocity = new Vector2(rd2.velocity.x, 0);
				rd2.AddForce (new Vector2(0, jumpForce));
				canJump = false;
				canDoubleJump = true;
			} 
			else {
				if (canDoubleJump) {
					AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().doubleJump, transform.position);
					canDoubleJump = false;
					rd2.velocity = new Vector2(rd2.velocity.x, 0);
					rd2.AddForce (new Vector2(0, jumpForce));
					canDoubleJump = false;
				}
			}
		}
	}

	public void handleDashMovimentation(){
		dashDelay += Time.deltaTime;
		if (dashDelay > 1) {
			canDash = true;
			dashDelay = 0;
		}

		if (Input.GetButtonDown (dash) && canDash) {
			AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().Dash, transform.position);
			if (faceRight) {
				anim.Play ("dash");
				transform.Translate(-dashForce * Time.deltaTime, 0, 0);
				//rd2.AddForce (new Vector2 (-dashForce, 0));
				canDash = false;
			} else {
				anim.Play ("dash");
				transform.Translate(dashForce * Time.deltaTime, 0, 0);
				//rd2.AddForce (new Vector2 (dashForce, 0));
				canDash = false;
			}
		}
	}

	//Flip player 
	public void Flip(){
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
		
	void identifyLive(){
		if (gameObject.transform.position.y <= 4)
			isAlive = true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Death")
			anim.Play ("Death");
	}
}