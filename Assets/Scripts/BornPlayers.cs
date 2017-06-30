using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornPlayers : MonoBehaviour {

//	public GameObject p1v;
//	public GameObject p2v;

	ChoosedPlayer[] players;


	public GameObject prefab1;
	public GameObject prefab2;

	// Use this for initialization
	void Start () {

		players = FindObjectsOfType<ChoosedPlayer> ();

		if (players[0].isOnGame == true) {
		
				Instantiate (prefab1, new Vector2 (-3.43f, -2.7f), Quaternion.identity);
		
		}

		if (players[1].isOnGame == true) {
		
			Instantiate (prefab2, new Vector2 (3.85f, -3.03f), Quaternion.identity);
		
		}

	}
	
	
	void Update () {
		
	}
}
