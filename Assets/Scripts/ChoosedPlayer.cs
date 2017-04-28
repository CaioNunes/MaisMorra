﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedPlayer : MonoBehaviour {

	public int id = 1;
	public bool isOnGame = false;

	public string select;
	public string moveLeft;
	public string moveRight;
	public string deselect;

	public GameObject colorMaster;
	public GameObject grays;
	private SpriteRenderer[] sprites;
	private SpriteRenderer[] colors;

	private bool canSelect = true;
	private int index = 0;

	void Start () {
		//Inicializando e preenchendo o array de sprites cinzas
		sprites = Initialize(sprites, grays);
		sprites [0].enabled = true;

		//Inicializando e preenchendo o array de sprites coloridos
		colors =  Initialize(colors, colorMaster);
	}
	
	// Update is called once per frame
	void Update () {
		if (canSelect) {
			if (Input.GetButtonDown (moveLeft)) {
				ToggleLeft ();
			}

			if (Input.GetButtonDown (moveRight)) {
				ToggleRight ();
			}

			if (Input.GetButtonDown (select)) {
				SelectPlayer ();
			}
		} else {
			if (Input.GetButtonDown (deselect)) {
				DeselectPlayer ();
			}
		}
	}

	void ToggleLeft(){

		//Toggle off the current sprite
		sprites[index].enabled = false;
		index--;

		if (index < 0)
			index = sprites.Length - 1;

		//Toggle on the new sprite
		sprites[index].enabled = true;
	}

	void ToggleRight(){

		//Toggle off the current sprite
		sprites[index].enabled = false;
		index++;

		if (index == sprites.Length)
			index = 0;

		//Toggle on the new sprite
		sprites[index].enabled = true;
	}

	SpriteRenderer[] Initialize(SpriteRenderer[] sprites, GameObject ob){
		sprites = new SpriteRenderer[ob.transform.childCount];

		for (int i = 0; i < ob.transform.childCount; i++) {
			sprites [i] = ob.gameObject.transform.GetChild (i).GetComponent<SpriteRenderer> ();
		}

		foreach (SpriteRenderer sp in sprites)
			sp.enabled = false;

		return sprites;
	}

	void SelectPlayer(){
		sprites [index].enabled = false;
		colors [index].enabled = true;
		canSelect = false;
	}

	void DeselectPlayer(){
		sprites [index].enabled = true;
		colors [index].enabled = false;
		canSelect = true;
	}
}
