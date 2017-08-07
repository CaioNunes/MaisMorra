using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private float timmerAttackDuration = 0;
    private float timmerAttack = 0;
    private bool attacking = false;
   
    public float attackDuration;
    public float attackCD;    
    public string punch;
    
    private Animator anim;


    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>(); 
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown(punch) && timmerAttack <= 0)
        {
            attacking = true;            
            timmerAttack = attackCD;
            timmerAttackDuration = attackDuration;            
        }

        if (attacking){
            TimmerAttack();
        }
        else{
            AttackCD();
        }
    }

    void TimmerAttack()
    {
        if (timmerAttackDuration > 0)
        {
            timmerAttackDuration -= Time.deltaTime;
        }
        else
        {
            attacking = false;            
        }
    }


    void AttackCD()
    {
        if (timmerAttack > 0){
            timmerAttack -= Time.deltaTime;            
        }        
    }  
    
    void OnHitPlayer(GameObject player)
    {
        if (attacking)
        {
            player.SendMessage("OnHitByPlayer");
        }
        
    }

    void OnHitByPlayer()
    {
        Debug.Log("Morri!!");
    }
}
