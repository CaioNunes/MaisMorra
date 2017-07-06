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
        foreach (ChoosedPlayer cs in FindObjectsOfType<ChoosedPlayer>())
            player.Add(cs);

        InstantiatePlayer();
    }

    // Update is called once per frame
    void Update(){

    }

    void InstantiatePlayer(){
        
        for (int i = 0; i < player.Count; i++){
            //Debug.Log(i);
            if (player[i].isOnGame){
                
                //Debug.Log(player[i].GetComponent<SpriteRenderer>().sprite.name);
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











