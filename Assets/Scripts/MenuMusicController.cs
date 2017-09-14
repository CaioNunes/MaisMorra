using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Start")
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {


        if (SceneManager.GetActiveScene().name != "Start" && SceneManager.GetActiveScene().name != "PlayerSelection" &&  SceneManager.GetActiveScene().name != "ModSelection" && SceneManager.GetActiveScene().name != "PressStart")
        {
            Destroy(this.gameObject);
        }
   
	}
}
