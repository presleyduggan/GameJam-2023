using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 offset;
    public float dampning;

    private Vector3 velocity = Vector3.zero;

    private float cameraZ;

    private void Start() {
        //target = player.transform;
        cameraZ = transform.position.z;
    }
 
    
    private void FixedUpdate() {
        //Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, cameraZ);
        //transform.position = newPos;
        Vector3 movePosition = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, dampning);
    }

}
