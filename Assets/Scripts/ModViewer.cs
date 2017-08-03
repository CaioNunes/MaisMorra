using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModViewer : MonoBehaviour {


    private GameManagerController gameManager;
    private ModSelection mod;
    public GameObject image;
    public GameObject title;
    public GameObject description;
    public string selectButton;
	
	// Update is called once per frame
	void Update () {

        ModSelection();

        if (Input.GetButtonDown(selectButton))
        {
            OnSelectMod();
        }

	}


    void ModSelection()
    {
        mod = EventSystem.current.currentSelectedGameObject.GetComponent<ModSelection>();
        image.GetComponent<Image>().sprite = mod.image;
        title.GetComponent<Image>().sprite = mod.title;
        description.GetComponent<Text>().text = mod.description;

    }

    private void OnSelectMod()
    {
        gameManager = FindObjectOfType<GameManagerController>();
        gameManager.modSelected = EventSystem.current.currentSelectedGameObject.name;
        LevelMananger loadLevel = new LevelMananger();
        loadLevel.LoadLevel("PlayerSelection");
    }
}
