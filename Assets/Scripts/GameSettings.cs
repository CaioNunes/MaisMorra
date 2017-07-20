using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameSettings : MonoBehaviour
{
    private bool fullScreen = true;
    private bool muteItAll = false;
    private float music = 1f;
    public AudioClip soundSelect;


    private void Awake()
    {
        if(FindObjectsOfType<GameSettings>().Length > 1)
        {
            DestroyImmediate(this.gameObject);
        }
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

    public float Music{
        get{
            return music;
        }

        set{
            music = value;
        }
    }


    

    
}




    

