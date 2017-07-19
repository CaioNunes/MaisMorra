using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Controller : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

        foreach (ChoosedPlayer cs in FindObjectsOfType<ChoosedPlayer>())
        {
            Destroy(cs.gameObject);
        }

    }


}
