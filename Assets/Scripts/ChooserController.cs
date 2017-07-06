using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooserController : MonoBehaviour {

    private List<ChoosedPlayer> sprites = new List<ChoosedPlayer>();
    private bool personagemRepetido;

	public string start;
	// Use this for initialization
	void Start () {

        foreach(ChoosedPlayer p in FindObjectsOfType<ChoosedPlayer>()){
            DontDestroyOnLoad (p);
            sprites.Add(p);
        }

        personagemRepetido = false;
	}
	
	// Update is called once per frame
	void Update () {

        PersonagemRepetido();

        if (Input.GetButtonDown (start)) {
            Debug.Log("dois jogadores:"+HaveTwoPlayers());
            Debug.Log("personagem repetido:" + personagemRepetido);
            if (HaveTwoPlayers() && personagemRepetido == false) {

                foreach (ChoosedPlayer sprite in sprites)
                {
                    sprite.GetComponent<SpriteRenderer>().enabled = false;
                }

                SceneManager.LoadScene ("Game");
                				
            }
		}
        
	}

    bool HaveTwoPlayers()
    {
        int playersInGame = 0;
        foreach(ChoosedPlayer player in sprites)
        {
            if (player.isOnGame)
            {
                playersInGame++;
            }
        }

        if (playersInGame >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    void PersonagemRepetido(){

        personagemRepetido = false;
        for(int i = 0; i < sprites.Count-1; i++)
        {
            if (sprites[i].isOnGame)
            {
                for (int j = i + 1; j < sprites.Count; j++)
                {
                    if (sprites[j].GetComponent<SpriteRenderer>().sprite.name == sprites[i].GetComponent<SpriteRenderer>().sprite.name)
                    {
                        personagemRepetido = true;
                    }

                }

            }    
        }
        
    }






}
