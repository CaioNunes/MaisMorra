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
    public GameObject panelMenuOptions;
    public GameObject buttonsMenu;

    public string abrirOptions;    
    public bool optionsIsOpen = false;
        
    
    private void Start()
    {
        if (!SceneManager.GetActiveScene().name.Equals("Start"))
        {
            buttonsMenu = null;
        }

        panelMenuOptions.SetActive(false);

        gameSettings = FindObjectOfType<GameSettings>();
        muteItAllToggle.isOn  = gameSettings.MuteItAll;
        musicSlider.value = gameSettings.MusicVolume;
                
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

            if (optionsIsOpen)
            {
                fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreen(); });
                musicSlider.onValueChanged.AddListener(delegate { OnMusic(); });
            }
    }
     
    public void AbrirMenuOptions(){
        if (optionsIsOpen)
        {
            if (SceneManager.GetActiveScene().name.Equals("Start"))
            {
                buttonsMenu.SetActive(true);
            }
            
            panelMenuOptions.SetActive(false);
            optionsIsOpen = false;                       
        }


        else
        {
            if (SceneManager.GetActiveScene().name.Equals("Start"))
            {
                buttonsMenu.SetActive(false);
            }
            
            panelMenuOptions.SetActive(true);
            optionsIsOpen = true;                       
        }

       
    }

    public void OnFullscreen(){
        Screen.fullScreen = gameSettings.FullScreen = fullScreenToggle.isOn;
    }

    public void OnMuteItAll(){
               
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
                    musicSource[i].volume = gameSettings.MusicVolume = musicSlider.value;
                }
                
            }                      
    }

    
    public void OnMusic(){
        if (muteItAllToggle.isOn == false)
        {
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = gameSettings.MusicVolume = musicSlider.value;
            }
        }
        
    }
           
    
    
}
