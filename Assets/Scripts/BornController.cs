using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornController : MonoBehaviour{

    //List <ChoosedPlayer> player = new List<ChoosedPlayer>();
    public List<ChoosedPlayer> player = new List<ChoosedPlayer>();
    
    public Sprite[] personagens;
    public GameObject[] prefabPlayer;
    public RuntimeAnimatorController[] animatorPlayer;


    private void Awake()
    {
        player.Clear();
        foreach (ChoosedPlayer ok in FindObjectOfType<GameManagerController>().GetComponent<GameManagerController>().players)
        {
            player.Add(ok);

        }       
    }


    // Use this for initialization
    void Start(){
        InstantiatePlayer();
    }
		
    // Update is called once per frame
    void Update(){

    }

    void InstantiatePlayer(){
        
        for (int i = 0; i < player.Count; i++){
            
            if (player[i].isOnGame){

                string spriteName = player[i].selectSprite.name;
                
                switch (spriteName){
                    case "TucanIDDLE3":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[0];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[0];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "VisorIDDLE3":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[1];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[1];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "RingPinkIDDLE3":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[2];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[2];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "RingBlueIDDLE3":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[3];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[3];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "MonkeyIDDLE3":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[4];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[4];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "FrogIDDLE3":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[5];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[5];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    default:
                        Debug.Log("Não foi identificado nenhum prefab ! Por favor, verifique os nomes !");
                        break;

                }

            }

        }

    }

	private class sort : IComparer<ChoosedPlayer>
	{
		int IComparer<ChoosedPlayer>.Compare(ChoosedPlayer x, ChoosedPlayer y)
		{
			int t1 = x.id;
			int t2 = y.id;
			return t1.CompareTo(t2);
		}
	}

}











