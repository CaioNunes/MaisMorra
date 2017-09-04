using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlighted : MonoBehaviour {

    private AudioSource selectSound;    

    private void Start()
    {
        selectSound = FindObjectOfType<GameSettings>().GetComponent<AudioSource>();
        selectSound.clip = FindObjectOfType<GameSettings>().soundSelect;
        selectSound.loop = false;
        selectSound.playOnAwake = false;      

    }

    public void OnSelectd()
    {
           selectSound.Play();
    }    
     
    
}
