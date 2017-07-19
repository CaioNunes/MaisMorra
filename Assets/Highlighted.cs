using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlighted : MonoBehaviour, IPointerEnterHandler  {

    private AudioSource selectSound;

    
    private void Start()
    {
        selectSound = FindObjectOfType<GameSettings>().GetComponent<AudioSource>();
        selectSound.clip = FindObjectOfType<GameSettings>().soundSelect;
        selectSound.loop = false;
        selectSound.playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
           selectSound.Play();
    }

    

    
}
