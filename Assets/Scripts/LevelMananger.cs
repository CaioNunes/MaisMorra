﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelMananger : MonoBehaviour {   
    

    public void LoadLevel(string name){        

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void Quit(){
		Application.Quit ();
	}

    public void Retry()
    {
        LoadLevel(FindObjectOfType<GameManagerController>().modSelected);
    }

    

    

	
}


