using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {

	MovePlayer[] players;

	// Use this for initialization
	void Start () {
		players = FindObjectsOfType<MovePlayer> ();
		for (int i = 0; i < players.Length; i++) {
			if (GetComponent<TextController> ().id > players [i].id) {
				this.GetComponent<Image>().enabled = false;
			} else {
				this.GetComponent<Image>().enabled = true;
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (players == null) {
			players = FindObjectsOfType<MovePlayer> ();
			for (int i = 0; i < players.Length; i++) {
				if (GetComponent<TextController> ().id > players [i].id) {
					this.GetComponent<Image>().enabled = false;
				} else {
					this.GetComponent<Image>().enabled = true;
				}
			}
		}
	}
}
