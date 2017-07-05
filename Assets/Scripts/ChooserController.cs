using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooserController : MonoBehaviour {

	public GameObject p1;
	public GameObject p2;
    private bool personagemRepetido;

	public string start;
	public bool haveTwoPlayers = false;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (p1);
		DontDestroyOnLoad (p2);
        personagemRepetido = false;
	}
	
	// Update is called once per frame
	void Update () {

        PersonagemRepetido();

        if (Input.GetButtonDown (start)) {
			if (haveTwoPlayers && personagemRepetido == false) {
				
				SceneManager.LoadScene ("Game");
				p1.GetComponent<SpriteRenderer> ().enabled = false;
				p2.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}


		if (p1.GetComponent<ChoosedPlayer> ().isOnGame && p2.GetComponent<ChoosedPlayer> ().isOnGame) {
			haveTwoPlayers = true;
		}
			
		
	}

    void PersonagemRepetido(){
        if(p1.GetComponent<SpriteRenderer>().sprite.name == p2.GetComponent<SpriteRenderer>().sprite.name){

            personagemRepetido = true;
        }
        else{
            personagemRepetido = false;
        }
    }






}
