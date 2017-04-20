using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedPlayer : MonoBehaviour {

	public int id = 1;
	public bool isOnGame = false;
	public string select;
	public Sprite sp1;
//	public int choosed = 0;
//	public int i = 0;

	// Use this for initialization
	void Start () {
		//id = GameObject.FindGameObjectWithTag ("Manager").GetComponent<ChooseCharacter> ().id;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown (select)) {
			isOnGame = true;
			gameObject.GetComponent<SpriteRenderer> ().sprite = sp1;
		}

	//	if (Mathf.Abs(Input.GetAxis (horizontal)) > 0) {
	//		Debug.Log ("Character choose :" + choosed);
	//		i++;
	//	}
	}
}
