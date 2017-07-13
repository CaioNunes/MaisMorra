using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings_Controller : MonoBehaviour {

    public Toggle fullScreenToggle;
    public Toggle muteItAllToggle;
    public Slider musicSlider;
    public Dropdown resolutionDropdown;
    

    public AudioSource[] musicSource;
    public Resolution[] resolutions;
    public GameSettings gameSettings;

    public string abrirOptions;
    public Canvas menuOptions;
    public bool isOpen = false;

    private static int instanceNew = 0;

    private void Awake() {
        instanceNew++;
    }

    private void Start()
    {
        Debug.Log(instanceNew);
        if (instanceNew > 1)
        {
            //Nothing to do.
        }
        else {
            DontDestroyOnLoad(this);
        }

        menuOptions.enabled = false;

        gameSettings = new GameSettings();
        muteItAllToggle.isOn = false;
        fullScreenToggle.isOn = false;
        musicSlider.value = 1;
        

        resolutions = Screen.resolutions;
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }




    void Update() {
        
        if (SceneManager.GetActiveScene().name == "PlayerSelection")
        {
            // Se estiver na tela de personagens nao muda settings
        }
        else
        {
            musicSource = FindObjectsOfType<AudioSource>();
            OnMuteItAll();
            OnFullscreen();
            OnResolution();
            OnMusic();


            if (Input.GetButtonDown(abrirOptions))
            {
                if (isOpen)
                {
                    menuOptions.enabled = false;
                    isOpen = false;
                }


                else
                {
                    menuOptions.enabled = true;
                    isOpen = true;
                }


            }



            if (isOpen)
            {
                fullScreenToggle.onValueChanged.AddListener(delegate { OnFullscreen(); });
                resolutionDropdown.onValueChanged.AddListener(delegate { OnResolution(); });
                musicSlider.onValueChanged.AddListener(delegate { OnMusic(); });
            }
        }
     }




    public void OnFullscreen()
    {
        Screen.fullScreen = gameSettings.fullScreen = fullScreenToggle.isOn;
    }

    public void OnMuteItAll()
    {
               
            for (int i = 0; i < musicSource.Length; i++)
            {
                if (muteItAllToggle.isOn)
                {
                    musicSource[i].volume = gameSettings.music = 0;
                }
                else
                {
                musicSource[i].volume = gameSettings.music = musicSlider.value;
            }
                
            }                      
    }

    
    public void OnMusic()
    {
        if (!muteItAllToggle.isOn)
        {
            for (int i = 0; i < musicSource.Length; i++)
            {
                musicSource[i].volume = gameSettings.music = musicSlider.value;
            }
        }
        
    }

    public void OnResolution()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, gameSettings.fullScreen);
    }

    
    public void SaveChanges()
    {

    }

    public void LoadSettings()
    {

    }
    
}
