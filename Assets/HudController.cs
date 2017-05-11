using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour {
	private int theScore;
	public Text scoreText;
	public Text finalScore;

	// Use this for initialization
	void Start () {
		theScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		theScore++;
		scoreText.text = "" + theScore;
	}

	public int getScore(){
		return this.theScore;
	}
}
