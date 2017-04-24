using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour {

	public AudioClip Dash;
	public AudioClip LandingJump;
	public AudioClip PlayerDying;
	public AudioClip Push;
	public AudioClip ToTheGround;
	public AudioClip jump;
	public AudioClip doubleJump;
	public AudioClip NaoPodePular;

	public void playJumpSound(){
		AudioSource.PlayClipAtPoint(jump, transform.position);
	}

}
