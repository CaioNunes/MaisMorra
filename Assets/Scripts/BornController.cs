using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornController : MonoBehaviour{

    ChoosedPlayer[] player;
    public Sprite[] personagens;
    public GameObject[] prefabPlayer;
    public RuntimeAnimatorController[] animatorPlayer;



    // Use this for initialization
    void Start(){

        player = FindObjectsOfType<ChoosedPlayer>();
        InstantiatePlayer();
    }

    // Update is called once per frame
    void Update(){

    }

    void InstantiatePlayer(){
        for (int i = 0; i < player.Length; i++){

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

                }

            }

        }



    }

}











