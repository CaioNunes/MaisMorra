using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBox : MonoBehaviour {

    public AudioClip voice;
    public AudioClip sound2;
    private bool colidiu = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
	}

    void OnTriggerEnter2D(Collider2D col) {
        AudioSource.PlayClipAtPoint(voice, transform.position);
    }
}
