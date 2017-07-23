using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosedPlayer : MonoBehaviour {

	public int id = 1;
	public bool isOnGame = false;
	public string select;
    public AudioSource trocaSound;

    public Sprite[] Personagens;//sprite de personagens
    public Sprite[] PersonagensOnGame;//sprite de confirmação de seleção dos personagens
    public string trocaRight;//Tecla de troca de personagem
    public string trocaLeft;
    private int indicePersonagens = 0;

    ChooserController telaDeSelecao;


   
    // Use this for initialization
    void Start () {
        telaDeSelecao = FindObjectOfType <ChooserController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (telaDeSelecao.selecao)
        {
            TrocaPersonagem();

        }     
        
                
        if (Input.GetButtonDown(select))
        {
            isOnGame = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = PersonagensOnGame[indicePersonagens];          

        }
      
    }


    void TrocaPersonagem(){

        if (Input.GetButtonDown(trocaRight))
        {
            trocaSound.Play();

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

        if (Input.GetButtonDown(trocaLeft))
        {

            trocaSound.Play();

            if (indicePersonagens == 0)
            {
                indicePersonagens = Personagens.Length - 1;
            }
            else
            {
                indicePersonagens--;
            }
            gameObject.GetComponent<SpriteRenderer>().sprite = Personagens[indicePersonagens];
        }

    }


}
