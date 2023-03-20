using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0;
    //private float attackCD = 0.3f;   //in case we need to add cooldowns


    public Collider2D attacktrigger;

    public void TaskOnClick()
    {
        Debug.Log("You have clicked! ");
    }
    
    private void Awake()
    {
        attacktrigger.enabled = true; //when the player clicks on the button
    }
    
    public void AttackClick()
    {
        attacking = true;
        attacktrigger.enabled = true;
    }

    void Update()
    {
        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attacktrigger.enabled = false;
            }
        }
    }
}
