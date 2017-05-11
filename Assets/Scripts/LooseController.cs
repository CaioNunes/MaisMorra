using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseController : MonoBehaviour {

	private MovePlayer[] players;
	private int playerQuantitie;

	void Start(){
		players = FindObjectsOfType<MovePlayer>();
	}

	void Update(){
		playerQuantitie = players.Length;
	}

	void OnCollisionEnter2D(Collision2D colidedObject){
		if(colidedObject.gameObject.tag == "Player"){
			Destroy(colidedObject.gameObject);
			playerQuantitie--;
		}
		changeSceneToWinner();
	}

	void changeSceneToWinner(){
		if(playerQuantitie == 0){
			SceneManager.LoadScene("Tie");
		}

		foreach (MovePlayer player in players) {
			if (player.isAlive == true) {
				switch(player.id){
					case 1:
						SceneManager.LoadScene ("Win1");
						break;
					case 2:
						SceneManager.LoadScene ("Win2");
						break;
				}
			}
		}
	}
}
