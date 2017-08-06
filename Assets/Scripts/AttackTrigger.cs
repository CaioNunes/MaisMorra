﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

     private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.name!= gameObject.name)
        {
            Debug.Log("hit");
        }
    }

}