using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsTest : MonoBehaviour {

    Light illumination;
    bool isOn = false;
    public string turnOn;

	// Use this for initialization
	void Start () {
        illumination = GetComponentInChildren<Light>();
        illumination.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(turnOn)) {
            if (isOn)
            {
                illumination.enabled = false;
                isOn = false;
            }
            else
            {
                illumination.enabled = true;
                isOn = true;
            }
                
        }
	}
}
