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



    void Update () {
        if(Playerinleft || Playerinright)
    {
        Shoot();
    }
    }

    void Shoot ()
    {
        Instantiate(PlantBulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("fire test");
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
             Playerinleft = false;
            Playerinright = true;
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
