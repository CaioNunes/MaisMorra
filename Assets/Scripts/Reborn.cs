using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reborn : MonoBehaviour {

	private MovePlayer controller;
	public Vector2 position;
	public Vector2 plataform_position;
	public GameObject plataform;
	public Text deathText;

	// Use this for initialization
	void Start () {
		controller = GetComponent<MovePlayer> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if(controller.deaths < 10)
//			deathText.text ="0" + (int)controller.deaths;
//		else
//			deathText.text ="" + (int)controller.deaths;
		

		if (controller.isAlive == false) {
			reborn_player ();
		}
			
	}

	void reborn_player(){
		gameObject.transform.position = position;
		Instantiate (plataform, plataform_position, Quaternion.identity);
		controller.isAlive = true;
	}
		
}
