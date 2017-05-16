﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	// Floats
	public float maxSpeed = 5f;
	public float moveForce = 365f;
	public float jumpForce = 1f;
	public float dashForce = 1000f;
	public float dashDelay = 0f;

	// Booleans
	public bool estaNoSolo;
	public bool canDoubleJump = true;
	public bool canDash = true;
	public bool isAlive = true;
	public bool faceRight = true;
	public bool wallCheck;
	public bool wallSliding;

	public Transform wallCheckPoint;
	public LayerMask wallLayerMask;
	public Transform testSolo;

	//Definitions
	public Rigidbody2D rd2;
	public Animator anim;
	public int id = 0;

	//Strings & References
	public string horizontalCtrl= "Horizontal_P1";
	public string jump = "Jump_P1";
	public string dash = "Dash_P1";

	void Start () {
		rd2 = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();
	}
	 
	void Update () {
		/// =========================== Movimentação ===============================
		if(!wallSliding){
			handleHorizontalMovimentation();
		}

		/// =========================== Pulo ================================
		estaNoSolo = Physics2D.OverlapCircle (testSolo.transform.position, 0.1f, 1 << LayerMask.NameToLayer ("Platform"));  
		handleJumpMovimentation();

		// =================== Dash =========================
		handleDashMovimentation();

		// =================== Wall Jump =========================
		HandleWallSliding();
	}

	//Handles Horizontal input and moves player
	public void handleHorizontalMovimentation(){
		float moveHorizontal = Input.GetAxis (horizontalCtrl);
		anim.SetFloat("move", Mathf.Abs(moveHorizontal));

		//TODO -> Refactor this ifs and use only one Flip() call
		if (moveHorizontal < 0 && !faceRight) {
			Flip ();
		} 
		else if (moveHorizontal > 0 && faceRight){
			Flip ();
		}

		if (moveHorizontal * rd2.velocity.x < maxSpeed) {
			rd2.AddForce (Vector2.right * moveHorizontal * moveForce);
		}
		if(Mathf.Abs(rd2.velocity.x) > maxSpeed)
			rd2.velocity = new Vector2(Mathf.Sign(rd2.velocity.x) * maxSpeed, rd2.velocity.y);
	}

	// Handles Jump when input is received
	public void handleJumpMovimentation(){
		if (Input.GetButtonDown (jump) && !wallSliding) {
			if (estaNoSolo) {
				AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().jump, transform.position);
				rd2.velocity = new Vector2(rd2.velocity.x, 0);
				rd2.AddForce (new Vector2(0, jumpForce));
				canDoubleJump = true;
			} 
			else {
				if (canDoubleJump) {
					AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().doubleJump, transform.position);
					canDoubleJump = false;
					rd2.velocity = new Vector2(rd2.velocity.x, 0);
					rd2.AddForce (new Vector2(0, jumpForce));
				}
			}
		}
	}

	public void handleDashMovimentation(){
	//TODO-> Constraint to check if dash is going to pass the edge of the map
		if (Input.GetButtonDown (dash) && canDash) {
			AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().Dash, transform.position);
			if (faceRight) {
				anim.Play ("dash");
				rd2.AddForce (new Vector2 (-dashForce, 0));
				//canDash = false;
			} else {
				anim.Play ("dash");
				rd2.AddForce (new Vector2 (dashForce, 0));
				//canDash = false;
			}
		}
		dashDelay += Time.deltaTime;
		if (dashDelay > 2) {
			canDash = true;
			dashDelay = 0;
		}
	}

	//Handles Wall Sliding and Wall Jumps
	public void HandleWallSliding(){
		wallCheck = Physics2D.OverlapCircle(wallCheckPoint.position, 0.1f, wallLayerMask);

		if(wallCheck && !estaNoSolo){
			wallSliding = true;
			canDoubleJump = true;

			rd2.velocity = new Vector2(0, -3f);

			if(Input.GetButtonDown(jump)){
				if(!faceRight){
					rd2.AddForce(new Vector2(-5,1) * jumpForce);
					Flip();
				}
				else {
					rd2.AddForce(new Vector2(5,1) * jumpForce);
					Flip();
				}
			}
		}
		if(!wallCheck || estaNoSolo){
			wallSliding = false;
		}
	}

	//Flip player 
	public void Flip(){
		faceRight = !faceRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}