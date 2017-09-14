using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosseControllerBlackout : MonoBehaviour {

    // Use this for initialization

    public List<MovePlayer> players = new List<MovePlayer>();  

    void Start () {
        players.Clear();
	}
	
	// Update is called once per frame
	void Update () {
        players.Clear();
        foreach (MovePlayer playerInGame in FindObjectsOfType<MovePlayer>())
        {
           players.Add(playerInGame);
        }
        if (players.Count == 1){            
            SceneManager.LoadScene("Win" + players[0].id);
        }        
          
	}
    
}
