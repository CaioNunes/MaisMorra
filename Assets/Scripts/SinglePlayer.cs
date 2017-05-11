using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SinglePlayer : MonoBehaviour {
	public GameObject p1;

	public string start;
	public bool haveOnePlayer = false;

	void Start () {
		DontDestroyOnLoad (p1);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown (start)) {
			Debug.Log("ok");
			if (haveOnePlayer) {
				SceneManager.LoadScene ("Game");
				p1.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}

		if (p1.GetComponent<ChoosedPlayer> ().isOnGame) {
			haveOnePlayer = true;
		}
	}
}
