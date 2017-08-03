using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ModSelection : MonoBehaviour {

    public string description;
    public Sprite title;
    public Sprite image;
    
    public GameObject onSelectImage;
    

	// Use this for initialization
	void Start () {        
        image = gameObject.GetComponent<Image>().sprite;
	}
	
	// Update is called once per frame
	void Update () {

        OnSelected();
        
    }



    private void OnSelected()
    {
        if(EventSystem.current.currentSelectedGameObject == gameObject)
        {
            onSelectImage.GetComponent<Image>().enabled = true;
            
        }
        else
        {
            onSelectImage.GetComponent<Image>().enabled = false;
        }



    }
}
