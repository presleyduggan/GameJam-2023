using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private bool isImmune = false;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
        startingHP = health;
    }

    public void TakeDamage(int damage, string damageText)
    {
        if(health > 0 && !isImmune){

        //  Debug.Log("taking damage of "+damage);

            health -= damage;

            

            if (health <= 0)
            {
            //   Debug.Log("killing player");
                Die(damageText);
                
            } else{

            // change color
            StartCoroutine(changeColor());
            }
        }
    }

    public void Die(string damageText)
    {
        // game manager stuff
       // Debug.Log("death function?");
        health = 0;
        Animator animator = GetComponent<Animator>();
        animator.SetBool("dead", true);
        gm.playerDied(damageText);
    }

    public void resetHP(){
        health = startingHP;
    }

    public void makeImmune(bool trait){
        isImmune = trait;
    }

    
}
