using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Plant : Enemy
{
    public Transform firePoint;
    public GameObject PlantBulletPrefab;
    public bool Playerinleft = false; 
    public bool Playerinright = false;

    private bool isShooting = false;

    public float waitTime = 2f; 

    private Animator animator;

    private GameObject target;

    private Vector3 forward;

    public GameObject zoneL;
    public GameObject zoneR;

    
    private void Start() {
        animator = GetComponent<Animator>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        target = players[0];
        if(target == null){
            // player is dead..
            Destroy(gameObject);
        }


    }



    void Update () {
        if((Playerinleft || Playerinright) && !isShooting)
    {
        StartCoroutine(Shoot());
    }
    }

    public IEnumerator Shoot()
    {
        isShooting = true;
        if(Playerinright){
            // turn plant left
            transform.eulerAngles = new Vector3(0,0,0);

            // play animation
            animator.SetBool("playerHere", true);

            // wait for animation
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength - 0.5f);
            animator.SetBool("playerHere", false);

            Vector3 temp = target.transform.position - transform.position;

            float angle = Vector2.Angle(transform.right, temp);

            //Debug.Log("angle = "+angle);

            Instantiate(PlantBulletPrefab, zoneR.transform.position,  Quaternion.Euler(new Vector3(0, 0, angle)));
            yield return new WaitForSeconds(waitTime);
            //Debug.Log("fire test");
        }
        else if(Playerinleft){
            // turn plant left
            transform.eulerAngles = new Vector3(0,180,0);

            // play animation
            animator.SetBool("playerHere", true);

            // wait for animation
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSecondsRealtime(animationLength - 0.6f);
            animator.SetBool("playerHere", false);

            Vector3 temp = target.transform.position - transform.position;

            float angle = Vector2.Angle(transform.right, temp);

            //Debug.Log("angle = "+angle);

            Instantiate(PlantBulletPrefab, zoneL.transform.position, Quaternion.Euler(new Vector3(0, 180, angle)));
            yield return new WaitForSeconds(waitTime);
        }
        isShooting = false;
    }
    public void Playerinzone (string direction)
    {
        if(String.Equals(direction, "left"))
        {
            Playerinleft = true;
            Playerinright = false;        
        }
        else
        {
            Playerinright = true;
            Playerinleft = false;
        }
    }
    public void Playernotinzone (string direction)
    {
        if(String.Equals(direction, "left"))
        {
            Playerinleft = false;   
        }
        else
        {
            Playerinright = false;
        }
    }
   
}
