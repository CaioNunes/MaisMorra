using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornController : MonoBehaviour{

    List <ChoosedPlayer> player = new List<ChoosedPlayer>();
    public Sprite[] personagens;
    public GameObject[] prefabPlayer;
    public RuntimeAnimatorController[] animatorPlayer;



    // Use this for initialization
    void Start(){

        player.Clear();
        foreach (ChoosedPlayer cs in FindObjectsOfType<ChoosedPlayer>()){
            player.Add(cs);
        }
        player.Sort((IComparer<ChoosedPlayer>)new sort());
        InstantiatePlayer();
    }

   

    // Update is called once per frame
    void Update(){

    }

    void InstantiatePlayer(){
        
        for (int i = 0; i < player.Count; i++){
            
            if (player[i].isOnGame){
                
                string spriteName = player[i].GetComponent<SpriteRenderer>().sprite.name;
                
                switch (spriteName){
                    case "mago_1":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[0];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[0];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "ovelha_1":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[1];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[1];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "peixe_1":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[2];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[2];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
                        break;

                    case "Respiracao_verdeM_0":
                        prefabPlayer[i].GetComponent<SpriteRenderer>().sprite = personagens[3];
                        prefabPlayer[i].GetComponent<Animator>().runtimeAnimatorController = animatorPlayer[3];
                        Instantiate(prefabPlayer[i], prefabPlayer[i].transform.position, Quaternion.identity);
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











