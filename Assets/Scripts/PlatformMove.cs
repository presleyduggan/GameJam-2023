using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private float xEnd;
    [SerializeField]
    private float yEnd;

    private float xStart;

    private float yStart;

    private float xvel;
    private float yvel;

    private bool xneg = true;
    private bool yneg = true;

    public bool waitForPlayer = false;

    public bool respawnIfPlayerDies = false;

    private GameObject player;
   // [SerializeField]
    private Vector3 original;
    //[SerializeField]
    private Vector3 destination;

    //private bool swap = false;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       // rb = this.GetComponent<Rigidbody2D>();
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
        xvel = yvel = 0;
        if(xEnd - xStart > 0){
            // move x in positive
            xvel = 1f;
        } else if(xStart - xEnd != 0){
            xvel = -1f;
            xneg = false;
        }
        if(yEnd - yStart > 0){
            yvel = 1f;
        } else if(yStart - yEnd != 0) {
            yvel = -1f;
            yneg = false;
        }

        if(respawnIfPlayerDies){
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            player = players[0];
            original = new Vector3(xStart, yStart, 0f);
            destination = new Vector3(xEnd, yEnd, 0);
        }

     //   Debug.Log("xvel = "+xvel+" and yvel="+yvel);

    }

    // Update is called once per frame
    void Update()
    {
        if((xEnd <= gameObject.transform.position.x && xvel != 0 && xneg) ||
        (xEnd >= gameObject.transform.position.x && xvel != 0 && !xneg)){
            xvel = xvel * -1;
            float temp = xStart;
            xStart = xEnd;
            xEnd = temp;
            xneg = !xneg;
        }
        if((yEnd <= gameObject.transform.position.y && yvel != 0 && yneg) ||
        (yEnd >= gameObject.transform.position.y && yvel != 0 && !yneg)){
            yvel = yvel * -1;
            float temp = yStart;
            yStart = yEnd;
            yEnd = temp;
            yneg = !yneg;
        }

        if(respawnIfPlayerDies){
            if(player.GetComponent<Player>().health <= 0){
                // respawn
                waitForPlayer = true;
                transform.position = original;
                xStart = transform.position.x;
                xEnd = destination.x;
                yStart = transform.position.y;
                yEnd = destination.y;
                //respawnIfPlayerDies = false;
            }
        }
    }

    private void FixedUpdate() {

        //rb.velocity = new Vector2(xvel * speed, yvel * speed);
        
        //transform.position = Vector2.MoveTowards(transform.position, )
        if(!waitForPlayer){
        transform.position += new Vector3(xvel * speed * Time.deltaTime, yvel * speed * Time.deltaTime, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(!waitForPlayer){
       // Debug.Log("collision!");
        other.transform.SetParent(transform);
        }
        else{
           // Debug.Log("collision on wait");
            waitForPlayer = false;
            other.transform.SetParent(transform);
        }
        //other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
       // Debug.Log(other.otherRigidbody.isKinematic);
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
        //other.otherRigidbody.isKinematic = false;
        //Debug.Log(other.otherRigidbody.isKinematic);

    }
}
