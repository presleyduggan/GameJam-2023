using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private bool isMovingY;
    [SerializeField]
    private bool isMovingX;

    [SerializeField]
    private float xEnd;
    [SerializeField]
    private float yEnd;

    private float xStart;

    private float yStart;

    private float xvel;
    private float yvel;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        xStart = gameObject.transform.position.x;
        yStart = gameObject.transform.position.y;
        xvel = yvel = 0;
        if(xStart - xEnd > 0){
            // move x in positive
            xvel = 1;
        } else{
            xvel = -1;
        }
        if(yStart - yEnd > 0){
            xvel = 1;
        } else {
            yvel = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(xEnd <= gameObject.transform.position.x || xStart > gameObject.transform.position.x){
            xvel = xvel * -1;
        }
        if(yEnd <= gameObject.transform.position.y || yStart > gameObject.transform.position.y){
            yvel = yvel * -1;
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(xvel * speed, yvel * speed);
    }
}
