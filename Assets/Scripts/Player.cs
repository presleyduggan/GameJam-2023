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

    public override void Die()
    {
        // game manager stuff
        Debug.Log("death function?");
        health = 0;
        gm.playerDied();
    }

    
}
