using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooserController : MonoBehaviour {    

    private GameManagerController gameManager;
    private bool personagemRepetido;
   
    public string retorno;
	public string start;
    public AudioSource falhaIniciar ;
    public AudioSource trocaSound;

    public Sprite[] Personagens;//sprite de personagens
    public Sprite[] PersonagensOnGame;//sprite de confirmação de seleção dos personagens

    // Use this for initialization
    void Start () {      

        gameManager = FindObjectOfType<GameManagerController>().GetComponent<GameManagerController>();
        gameManager.selecaoPersonagem = true;
        personagemRepetido = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown (start)) {
            GameReadyToStart();          
		}

        if (Input.GetButtonDown(retorno)){
            SceneManager.LoadScene("Start");
        }
        
	}


    void GameReadyToStart()
    {
        PersonagemRepetido();

        if (HaveTwoPlayers() && !personagemRepetido){

            //SceneManager.LoadScene(gameManager.modSelected);
            for(int i = 0;i < gameManager.players.Count; i++)
            {
                DontDestroyOnLoad(gameManager.players[i]);
                gameManager.players[i].GetComponent<SpriteRenderer>().enabled = false;
            }
           
            SceneManager.LoadScene("SurvivalMod");            
        }
        else
        {
            falhaIniciar.Play();
        }
    }



    bool HaveTwoPlayers()
    {
        int playersInGame = 0;
        foreach(ChoosedPlayer player in gameManager.players)
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
        for(int i = 0; i < gameManager.players.Count-1; i++)
        {
            if (gameManager.players[i].isOnGame)
            {
                for (int j = i + 1; j < gameManager.players.Count; j++)
                {
                    if (gameManager.players[j].selectSprite.name.Equals(gameManager.players[i].selectSprite.name))
                    {
                        personagemRepetido = true;
                    }

                }

            }    
        }
        
    }






}
