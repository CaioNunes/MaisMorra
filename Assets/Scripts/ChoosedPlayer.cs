using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosedPlayer : MonoBehaviour {

   	public int id = 1;
	public bool isOnGame = false;
    public Sprite selectSprite;      

    public string select;
    public string trocaRight;//Tecla de troca de personagem para direita
    public string trocaLeft;//Tecla de troca de personagem para esquerda

    private ChooserController controller;
    private int indicePersonagens = 0;
    private string deselect ;
   
    // Use this for initialization
    void Start () {
        deselect = "Dash_P" + id;
        controller = FindObjectOfType <ChooserController>();
        selectSprite = gameObject.GetComponent<SpriteRenderer>().sprite ;
    }
	
	// Update is called once per frame
	void Update () {        

        if (SceneManager.GetActiveScene().name.Equals("PlayerSelection"))
        {
            TrocaPersonagem();            
        }

        if (Input.GetButtonDown(deselect))
        {
            if (isOnGame)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = controller.Personagens[indicePersonagens];
                isOnGame = false;
            }
            else
            {
                if(id == 1)
                {
                    SceneManager.LoadScene("ModSelection");
                }
            }
            
        }
        
        
                
        if (Input.GetButtonDown(select))
        {
            isOnGame = true;
            selectSprite = controller.PersonagensOnGame[indicePersonagens];
            gameObject.GetComponent<SpriteRenderer>().sprite = selectSprite;            
        }
         
    }

    void TrocaPersonagem(){

        if (Input.GetButtonDown(trocaRight) && !isOnGame)
        {
            controller.trocaSound.Play();

            if (indicePersonagens == controller.Personagens.Length - 1)
            {
                indicePersonagens = 0;
            }
            else
            {
                indicePersonagens++;
            }
            selectSprite = controller.Personagens[indicePersonagens];
            gameObject.GetComponent<SpriteRenderer>().sprite = selectSprite;
        }

        if (Input.GetButtonDown(trocaLeft) && !isOnGame)
        {
            controller.trocaSound.Play();

            if (indicePersonagens == 0)
            {
                indicePersonagens = controller.Personagens.Length - 1;
            }
            else
            {
                indicePersonagens--;
            }
            selectSprite = controller.Personagens[indicePersonagens];
            gameObject.GetComponent<SpriteRenderer>().sprite = selectSprite;
        }

    }


   
        
    




}
