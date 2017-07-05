using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
	private float seconds;
    private int minutes;
    public bool end = false;
	public Text scoreText;
	

	// Use this for initialization
	void Start () {
		minutes = 1;
        seconds = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (minutes >= 0 && seconds >= 0f){
            if ((int)seconds == 0f && minutes > 0){
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
            scoreText.text = "Time Offer!!";
            end = true;
        }

	}

    
    }

    
    	

