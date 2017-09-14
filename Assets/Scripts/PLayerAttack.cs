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
    private LightsTest t;

    LightController lc;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        t = gameObject.GetComponent<LightsTest>();
        lc = GameObject.FindObjectOfType<LightController>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown(punch) && timmerAttack <= 0)
        {
            AudioSource.PlayClipAtPoint(gameObject.GetComponent<PlayerSoundController>().attack, transform.position);
            anim.Play("punch");
            attacking = true;            
            timmerAttack = attackCD;
            timmerAttackDuration = attackDuration;
        }

        if (attacking){

            t.illumination.enabled = true;
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
            if ((lc.atual_player_lighted + 1 ) == t.id )
            {

            }
            else {
                t.illumination.enabled = false;
            }
            
        }
    }


    void AttackCD()
    {
        if (timmerAttack > 0){
            timmerAttack -= Time.deltaTime;            
        }        
    }  
    
    public void OnHitPlayer(GameObject player)
    {
        if (attacking)
        {
            player.SendMessage("OnHitByPlayer");            
        }
        
    }

    public void OnHitByPlayer()
    {
        gameObject.GetComponent<MovePlayer>().isAlive = false;
        LightController p = FindObjectOfType<LightController>();
        p.player_was_dead = true;
        gameObject.GetComponent<MovePlayer>().isAlive = false;
        //Destroy(gameObject);        
    }
}
