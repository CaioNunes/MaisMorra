using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
	private float seconds;
    private int minutes;
    private bool end = false;
	public Text scoreText;
	

	// Use this for initialization
	void Start () {
		minutes = 3;
        seconds = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        if(minutes >= 0 && seconds >= 0){
            if (seconds <= 0f){
                minutes--;
                seconds = 60f;
            }
            seconds -= Time.deltaTime;
            if (seconds < 10){
                scoreText.text = minutes + ":0" + (int)seconds;
            }
            else{
                scoreText.text = minutes + ":" + (int)seconds;
            }

        }
        else{
            end = true;
        }

	}

    
    }

    
    	

