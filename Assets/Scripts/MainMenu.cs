using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public float count = 0f;

	// Update is called once per frame
	void Update () {

		count += Time.deltaTime;

		if(count >= 2)
			SceneManager.LoadScene ("Start");
	}
}
