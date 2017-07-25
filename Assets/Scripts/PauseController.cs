using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour {	
    private bool paused = false;
    public string pauseButton;

    
    void Update()
    {
        if (Input.GetButtonDown(pauseButton))
        {
            PauseGame();
        }
        
    }

        bool togglePause() {
            if (Time.timeScale == 0f) {
                Time.timeScale = 1f;
                return (false);
            }
            else {
                Time.timeScale = 0f;
                return (true);
            }
        }
        
        public void PauseGame(){
          paused = togglePause();
        }
    
}
