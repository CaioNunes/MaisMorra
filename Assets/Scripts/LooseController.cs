﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseController : MonoBehaviour {

	private MovePlayer[] players;
    private TimerController timer;
    private int lessDeath = 10000;
	private List<int> playersTieId = new List<int>();
    private bool deathmatch = false;

	void Start(){
        players = FindObjectsOfType<MovePlayer>();
        timer = FindObjectOfType<TimerController>();
    }

	void Update(){
		if (timer.end) {
			changeSceneToWinner();
		}
	}

	void OnTriggerEnter2D(Collider2D colidedObject){

		if(colidedObject.gameObject.tag == "Player" && colidedObject.gameObject.GetComponent<MovePlayer>().isAlive == true){
			if (deathmatch == false) {
				Debug.Log ("Colidiu no modo Normal !\n");
				colidedObject.gameObject.GetComponent<MovePlayer> ().isAlive = false;
                colidedObject.gameObject.GetComponent<MovePlayer>().deaths++;
            } else {
				Debug.Log ("Colidiu no modo Morte Súbita\n");
                colidedObject.gameObject.GetComponent<MovePlayer>().isAlive = false;
                colidedObject.gameObject.GetComponent<MovePlayer>().deaths++;
                Destroy(colidedObject.gameObject);
                changeSceneToWinner();
            }   
		}
            
    }

	void changeSceneToWinner(){

		playersTieId.Clear();
        //Identifica menor quantidade de mortes
        for (int i = 0; i<players.Length; i++){
            if (players[i].deaths < lessDeath){
                lessDeath = players[i].deaths;
            }
        }
	
        //Adiciona na lista de empates todos que tiveram a menor quantidade de mortes
        for(int i = 0; i < players.Length; i++){
            if (players[i].deaths == lessDeath){
                playersTieId.Add(players[i].id);
            }
        }
	
        //Verifica se houve empate ou não, e define o estado baseado nisso.
        if (playersTieId.Count == 1){
			SceneManager.LoadScene("Win"+playersTieId[0]);
        } else {
            deathmatch = true;
            foreach (MovePlayer player in players) {
                if (playersTieId.Contains(player.id)) {
                    //Nothing to do
                }
                else{
                    Destroy(player.gameObject);
                }
            }
        }	
	}
}