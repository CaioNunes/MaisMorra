using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelMananger : MonoBehaviour {

    
    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("PressStart"))
        {
            OnPressStartScene();
        }
        
        
    }



    public void LoadLevel(string name){        

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void Quit(){
		Application.Quit ();
	}

    void OnPressStartScene()
    {                
            if (Input.GetButton("Start"))
            {
                SceneManager.LoadScene("Start", LoadSceneMode.Single);
            }        
    }

    public void SoundButtonsHilighted()
    {
        AudioSource sound = FindObjectOfType<GameManagerController>().GetComponent<AudioSource>();
        sound.loop = false;
        sound.playOnAwake = false;
        sound.Play();
    }

	
}


