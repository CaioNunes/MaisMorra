using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSelect : MonoBehaviour {

    public Button start;
    public Button options;
    public Button quit;
    private int cont = 0;
    public string jump_p1;

	// Use this for initialization
	void Start () {
        start.Select();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown(jump_p1)) {
            if (start.enabled)
                Debug.Log("Pressionou o botão");
        }
	}
}
