﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.tag != "Player" || other.gameObject.tag == "Bullet")
			Destroy(other.gameObject);
	}

}