﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMananger : MonoBehaviour {

	public void LoadLevel(string name){
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void Quit(){
		Application.Quit ();
	}
	
}
