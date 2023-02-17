using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointElevator : MonoBehaviour
{
    public float speed;
    public bool waitForPlayer = true;
    private bool startingWait;

    [SerializeField]
    private int currentPointIndex = 0;

    public List<Transform> waypoints;

    private Player player;

    private Vector3 startingPosition;

    private bool timeToRespawn = false;

    private void Start() {
        currentPointIndex = 0;
        startingPosition = transform.position;
        startingWait = waitForPlayer;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0].GetComponent<Player>();
    }


    private void FixedUpdate() {
        if(!waitForPlayer){
            if (transform.position != waypoints[currentPointIndex].position)
            {       
                transform.position = Vector2.MoveTowards(transform.position,waypoints[currentPointIndex].position, speed * Time.deltaTime);
            } 

            if(transform.position == waypoints[currentPointIndex].position){
                if(currentPointIndex < waypoints.Count - 1){
                    currentPointIndex++;
                }
            }
        }
    }

    private void Update() {
        if(player.health <= 0){
            freezeElevator();
        } else if(player.health > 0 & timeToRespawn)
        {
            resetElevator();
            timeToRespawn = false;
        }
    }


    private void resetElevator(){
        waitForPlayer = startingWait;
        currentPointIndex = 0;
        transform.position = startingPosition;
    }

    private void freezeElevator(){
        waitForPlayer = true;
        timeToRespawn = true;
        player.transform.SetParent(null);
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(!waitForPlayer){
        other.transform.SetParent(transform);
        }
        else{
            waitForPlayer = false;
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
    

    }



}
