using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager2 : MonoBehaviour {

	public float count = 0f;
	public string p1;
	public string p2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if(count >= 2)
			SceneManager.LoadScene ("Start");
	}

}
