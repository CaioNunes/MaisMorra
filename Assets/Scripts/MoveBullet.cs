using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public float direction;
    public float bullet_speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(direction > 0)
            transform.Translate(bullet_speed * Time.deltaTime, 0, 0);
        else
            transform.Translate(-bullet_speed * Time.deltaTime, 0, 0);

        if (transform.position.x >= 12f || transform.position.x <= -12f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col) {
        GameObject player = col.gameObject;
        if (player.tag == "Player") {
            //player.GetComponent<MovePlayer>().isAlive = false;
            //player.GetComponent<MovePlayer>().deaths++;

            //Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
