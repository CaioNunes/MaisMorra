using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.gameObject != gameObject){
            Debug.Log("Dentro do colisor");
            gameObject.SendMessageUpwards("OnHitPlayer",other.gameObject);
        }             
    }

}
