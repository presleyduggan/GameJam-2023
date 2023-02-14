using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {

        Debug.Log("taking damage of "+damage);

        health -= damage;

        

        if (health <= 0)
        {
            Die();
        }

        // change color
        StartCoroutine(changeColor());
    }

    void Die ()
    {
        if(deathEffect != null)
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator changeColor(){

        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);

        yield return new WaitForSecondsRealtime(.5f);

        renderer.material.SetColor("_Color", Color.white);



        //renderer.sortingLayerID = SortingLayer.NameToID("Weapons");
    }
    
}
