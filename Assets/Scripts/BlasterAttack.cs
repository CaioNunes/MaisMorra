using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterAttack : MonoBehaviour {

    public float delay = 0;
    public float speed = 0;
    public float position_max = 0;
    public float position_min = 0;
    public GameObject bullet;
    private float cont = 0;
    private bool isMoveUp = false;
    private bool isMoveDown = true;
    private GameObject bullet_instance;
    public Transform pontaGanhao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        attack();
        move_blaster();
    }

    void attack() {
        cont += Time.deltaTime;
        if (cont >= delay){
            bullet_instance = Instantiate(bullet, new Vector2(pontaGanhao.position.x + 2f, pontaGanhao.position.y), Quaternion.identity) as GameObject;

            if (transform.position.x <= 0){
                bullet_instance.GetComponent<MoveBullet>().direction = 1f;
            }else {
                bullet_instance.GetComponent<MoveBullet>().direction = -1f;
                bullet_instance.GetComponent<SpriteRenderer>().flipX = true;
            }
                

            cont = 0;
        }
    }

    void move_blaster(){
        
        if (transform.position.y >= position_min && isMoveDown){            
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }else {
            isMoveDown = false;
            isMoveUp = true;
        }

        if (transform.position.y <= position_max && isMoveUp){            
            transform.Translate(0, speed * Time.deltaTime, 0);
        }else {
            isMoveUp = false;
            isMoveDown = true;
        }
    }
}
