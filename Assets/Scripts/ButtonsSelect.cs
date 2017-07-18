using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonsSelect : MonoBehaviour {

    public Button screen;
    public Button music;
    public Button full;
    private List<Button> buttons;

    public string button_up;
    public string button_down;
    public string button_left;
    public string button_right;
    public string button_select;

    private int button_selected = 0;

    // Use this for initialization
    void Start() {
        buttons.Add(screen);
        buttons.Add(music);
        buttons.Add(full);

        buttons[0].Select();
    }

    // Update is called once per frame
    void Update() {
        
	}

    void move_up() {
        if (Input.GetButtonDown(button_down)){

            if (button_selected == buttons.Count - 1){
                button_selected = 0;
            }else{
                button_selected++;
            }

            //Where play button animation
        }

    }


}
