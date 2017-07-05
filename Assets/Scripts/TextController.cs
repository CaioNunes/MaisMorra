using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public MovePlayer controller;
	private MovePlayer[] all;
	public Text deathText;
	public int id;

	// Use this for initialization
	void Start () {
		all = FindObjectsOfType<MovePlayer> ();

		foreach(MovePlayer player in all){
			if (player.GetComponent<MovePlayer> ().id == id)
				controller = player;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (controller == null) {
			all = FindObjectsOfType<MovePlayer> ();

			foreach(MovePlayer player in all){
				if (player.GetComponent<MovePlayer> ().id == id)
					controller = player;
			}
		}

		if(controller.deaths < 10)
			deathText.text ="0" + (int)controller.deaths;
		else
			deathText.text ="" + (int)controller.deaths;
		
	}
}
