using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings_Controller : MonoBehaviour {

    public Toggle fullScreenToggle;
    public Toggle muteItAllToggle;
    public Slider musicSlider; 
    public AudioSource[] musicSource;
    public GameSettings gameSettings;

    public string abrirOptions;
    public Canvas canvasMenuOptions;
    public bool isOpen = false;
        
    
    private void Start()
    {
        
        canvasMenuOptions.enabled = false;

        gameSettings = FindObjectOfType<GameSettings>();
        muteItAllToggle.isOn = gameSettings.MuteItAll;
        Debug.Log(muteItAllToggle.isOn);
        musicSlider.value = gameSettings.Music;
        

        
    }




    void Update() {
                
            musicSource = FindObjectsOfType<AudioSource>();
            OnMuteItAll();
            OnFullscreen();
            OnMusic();


            if (Input.GetButtonDown(abrirOptions))
            {
            AbrirMenuOptions();
            }



            if (isOpen)
            {
                fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreen(); });
                musicSlider.onValueChanged.AddListener(delegate { OnMusic(); });
            }
    }
     


    public void AbrirMenuOptions()
    {
        if (isOpen)
        {
            canvasMenuOptions.enabled = false;
            isOpen = false;
        }


        else
        {
            canvasMenuOptions.enabled = true;
            isOpen = true;
        }
    }

    public void OnFullscreen()
    {
        Screen.fullScreen = gameSettings.FullScreen = fullScreenToggle.isOn;
    }

    public void OnMuteItAll()
    {
               
            for (int i = 0; i < musicSource.Length; i++)
            {
                if (muteItAllToggle.isOn == true)
                {
                    gameSettings.MuteItAll = true;
                    musicSource[i].volume = 0 ;
                }
                else
                {
                    gameSettings.MuteItAll = false;
                    musicSource[i].volume = gameSettings.Music = musicSlider.value;
                }
                
            }                      
    }

    
    public void OnMusic()
    {
        if (muteItAllToggle.isOn == false)
        {
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = gameSettings.Music = musicSlider.value;
            }
        }
        
    }
           
    
    
}
