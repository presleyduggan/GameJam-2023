using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeSwam : FollowEnemy {
    private void Start() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        target = players[0].transform;
        if(target == null){
            // player is dead..
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }



        if(target.GetComponent<Player>().health <= 0){
            //Debug.Log("killing bee");
            // kill the bee
            Destroy(gameObject);
            
        }

        // flip the sprite
        if(transform.position.x >target.position.x){
                    transform.eulerAngles = new Vector3(0,0,0);
                } else{
                    transform.eulerAngles = new Vector3(0,180,0);
                }
    }
}