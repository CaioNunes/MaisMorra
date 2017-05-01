using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornPlayers : MonoBehaviour {

	public GameObject prefab1;
	public GameObject prefab2;
	public int index;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < ChoosedPlayer.isOnGame.Length; i++) {
			if (ChoosedPlayer.isOnGame [i] == true) {
				switch (ChoosedPlayer.index + 1) {
				case 1:
					Debug.Log ("Instanciou Mago");
					Instantiate (prefab1, new Vector2 (-1.24f, 0f), Quaternion.identity);
					break;
				case 2:
					Debug.Log ("Instanciou ovelha");
					Instantiate (prefab2, new Vector2 (-1.24f, 0f), Quaternion.identity);
					break;
				}		
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
