using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooserController : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;

	public string start;
	public bool haveTwoPlayers = false;
	private 
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (p1);
		DontDestroyOnLoad (p2);
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(p2.GetComponent<SpriteRenderer>().sprite.name);
        if (Input.GetButtonDown (start)) {
			if (haveTwoPlayers) {
				
				SceneManager.LoadScene ("Game");
				p1.GetComponent<SpriteRenderer> ().enabled = false;
				p2.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}


		if (p1.GetComponent<ChoosedPlayer> ().isOnGame && p2.GetComponent<ChoosedPlayer> ().isOnGame) {
			haveTwoPlayers = true;
		}
			
		
	}
}
