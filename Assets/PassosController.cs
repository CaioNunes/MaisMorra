using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassosController : MonoBehaviour {

    List<MovePlayer> inGame = new List<MovePlayer>();
    AudioClip attack;
    // Use this for initialization
    void Start () {
        foreach (MovePlayer playerInGame in FindObjectsOfType<MovePlayer>())
        {
            inGame.Add(playerInGame);
        }
    }
	
	// Update is called once per frame
	void Update () {
        foreach (MovePlayer player in inGame) {
            AudioSource.PlayClipAtPoint(attack, transform.position);
        }
    }
}
