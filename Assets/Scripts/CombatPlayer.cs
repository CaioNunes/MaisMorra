using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour {

	public string punch ;
	public float attackForce;
	public bool canAttack = true;
	private float delayAttack = 0f;
	public float maxSpeed = 5f;
	public Animator anim;
	public float dashForce;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {

		delayAttack += Time.deltaTime;

		if (delayAttack > 0.5f) {
			canAttack = true;
		}

		if (Input.GetButtonDown (punch) && canAttack) {
			anim.Play ("punch");
			canAttack = false;
			delayAttack = 0;
		}
	
	}

	void OnTriggerStay2D(Collider2D other){

		if (Input.GetButtonDown (punch) && other.gameObject.tag == "Player" && canAttack) {
			anim.Play ("punch");
			if(GetComponent<MovePlayer>().faceRight == other.gameObject.GetComponent<MovePlayer>().faceRight){
				other.gameObject.GetComponent<MovePlayer> ().Flip ();
			}

			other.gameObject.GetComponent<Animator> ().Play ("caindo");

			if (!GetComponent<MovePlayer>().faceRight) {
				other.gameObject.GetComponent<MovePlayer> ().rd2.AddForce (new Vector2 (-attackForce, 0));
			} else {
				other.gameObject.GetComponent<MovePlayer>().rd2.AddForce (new Vector2 (attackForce, 0));
			}

			canAttack = false;
			delayAttack = 0;
		}
	}
		
}
