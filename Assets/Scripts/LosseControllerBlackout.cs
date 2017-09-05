using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosseControllerBlackout : MonoBehaviour {

    // Use this for initialization

    public MovePlayer[] players;  

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        players = FindObjectsOfType<MovePlayer>();
        if (players.Length == 1){            
            SceneManager.LoadScene("Win" + players[0].id);
        }        
          
	}
    
}
