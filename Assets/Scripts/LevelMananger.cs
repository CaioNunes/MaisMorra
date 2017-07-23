using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMananger : MonoBehaviour {

    


    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("PressStart"))
        {
            if (Input.GetButton("Start"))
            {
                SceneManager.LoadScene("Start", LoadSceneMode.Single);
            }

        }
    }



    public void LoadLevel(string name){        

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void Quit(){
		Application.Quit ();
	}
	
}
