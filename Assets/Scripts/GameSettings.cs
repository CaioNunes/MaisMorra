using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSettings : MonoBehaviour
{
    private bool fullScreen;
    private bool muteItAll = false;
    private float musicVolume = 1f;
    public AudioClip soundSelect;

    private void Awake()
    {
        FullScreen = Screen.fullScreen;        
    }


    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public bool FullScreen{
        get{
            return fullScreen;
        }

        set{
            fullScreen = value;
        }
    }

    public bool MuteItAll{
        get{
            return muteItAll;
        }

        set{
            muteItAll = value;
        }
    }

    public float MusicVolume{
        get{
            return musicVolume;
        }

        set{
            musicVolume = value;
        }
    }


    

    
}




    

