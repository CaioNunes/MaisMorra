using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    public GameObject lastSelectedGameObject;

    private void Awake()
    {
        gameSettings = FindObjectOfType<GameManagerController>().GetComponent<GameSettings>();
    }

    private void Start()
    {
        Screen.fullScreen = fullScreenToggle.isOn = gameSettings.fullScreen;
        muteItAllToggle.isOn = gameSettings.muteItAll;
        musicSlider.value = gameSettings.musicVolume;

        

        OnMuteItAll();

        panelMenuOptions.SetActive(false);


        if (!SceneManager.GetActiveScene().name.Equals("Start"))
        {
            buttonsMenu = null;
        }        
    }

    
    void Update() {              
            
        musicSource = FindObjectsOfType<AudioSource>();
        OnMuteItAll();


        if (Input.GetButtonDown(abrirOptions))
            {
            AbrirMenuOptions();
            }

            if (optionsIsOpen)
            {  
                fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreen(); });
                musicSlider.onValueChanged.AddListener(delegate { OnMusic(); });
                muteItAllToggle.onValueChanged.AddListener(delegate { OnMuteItAll(); });
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

            EventSystem.current.SetSelectedGameObject(lastSelectedGameObject);
        }


        else
        {
            lastSelectedGameObject = EventSystem.current.currentSelectedGameObject;
            fullScreenToggle.GetComponent<Selectable>().Select();

            if (SceneManager.GetActiveScene().name.Equals("Start"))
            {
                buttonsMenu.SetActive(false);
            }
            
            panelMenuOptions.SetActive(true);
            optionsIsOpen = true;                       
        }

       
    }

    public void OnFullscreen(){
        //Screen.fullScreen = FindObjectOfType<GameSettings>().fullScreen = fullScreenToggle.isOn;
        Screen.fullScreen = gameSettings.fullScreen = fullScreenToggle.isOn;
    }

    public void OnMuteItAll(){
               
            for (int i = 0; i < musicSource.Length; i++)
            {
                if (gameSettings.muteItAll)
                {
                 musicSource[i].volume = 0 ;
                }
                else
                {                
                musicSource[i].volume = gameSettings.musicVolume = musicSlider.value;
                }
                
            }
        gameSettings.muteItAll = muteItAllToggle.isOn;
    }

    
    public void OnMusic(){
        if (muteItAllToggle.isOn == false)
        {
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = gameSettings.musicVolume = musicSlider.value;
            }
        }
        else
        {
            gameSettings.musicVolume = musicSlider.value;
        }
        
    }
           
    
    
}
