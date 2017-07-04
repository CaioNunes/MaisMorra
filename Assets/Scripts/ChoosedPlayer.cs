using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedPlayer : MonoBehaviour {

	public int id = 1;
	public bool isOnGame = false;
	public string select;

    public Sprite[] Personagens;//sprite de personagens
    public Sprite[] PersonagensOnGame;//sprite de confirmação de seleção dos personagens
    public string troca;//Tecla de troca de personagem
    private int indicePersonagens = 0;


   
    // Use this for initialization
    void Start () {
       
        
    }
	
	// Update is called once per frame
	void Update () {
        
        //Troca de sprite
        if (Input.GetButtonDown(troca))
        {

            if (indicePersonagens == Personagens.Length - 1)
            {
                indicePersonagens = 0;
            }
            else
            {
                indicePersonagens++;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = Personagens[indicePersonagens];
        }
       
        //Confirma o jogador e muda o sprite para o sprite de confirmação
        if (Input.GetButtonDown(select))
        {
            isOnGame = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = PersonagensOnGame[indicePersonagens];          

        }
  
    }
}
