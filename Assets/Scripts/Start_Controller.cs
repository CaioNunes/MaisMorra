using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Controller : MonoBehaviour {
    Settings_Controller[] settings;

    // Use this for initialization
    void Start () {
        
        foreach (ChoosedPlayer cs in FindObjectsOfType<ChoosedPlayer>())
        {
            Destroy(cs.gameObject);
        }
                
    }

    // Update is called once per frame
    void Update () {

        settings = FindObjectsOfType<Settings_Controller>();
        if (settings.Length > 1)
        {
            DestroyObject(settings[1]);
        }
    }
}
