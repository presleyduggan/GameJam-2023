using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    [SerializeField]
    private GameManager gm;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage, string damageText)
    {

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

    public void Die(string damageText)
    {
        // game manager stuff
       // Debug.Log("death function?");
        health = 0;
        gm.playerDied(damageText);
    }

    
}
