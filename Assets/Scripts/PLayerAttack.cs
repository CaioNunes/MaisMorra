using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAttack : MonoBehaviour {

    private float timmerAttackDuration = 0;
    private float timmerAttack = 0;
    private bool attacking = false;

    public float attackDuration;
    public float attackCD;    
    public string punch;

    public Collider2D attackTrigger;
    private Animator anim;


    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        //attackTrigger.enabled = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown(punch) && !attacking)
        {
            attacking = true;
            attackTrigger.enabled = true;
            timmerAttack = attackCD;
            timmerAttackDuration = attackDuration;

        }

        if (attacking)
        {
            AttackDuration();
            AttackCD();            
        }

       

	}

    void AttackDuration()
    {     
        if(timmerAttackDuration > 0)
        {
            timmerAttackDuration -= Time.deltaTime;                        
        }else{            
            //attackTrigger.enabled = false;
        }
    }

    void AttackCD()
    {        
        if (timmerAttack > 0)
        {
            timmerAttack -= Time.deltaTime;            
        }
        else
        {            
            attacking = false;
        }
    }
}
