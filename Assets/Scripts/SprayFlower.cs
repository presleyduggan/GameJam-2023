using UnityEngine;
using System.Collections.Generic;


public class SprayFlower : Damage {

    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void startSpray(){
        animator.SetBool("playerHere", true);
    }

    public void stopSpray(){
        animator.SetBool("playerHere", false);
    }

}