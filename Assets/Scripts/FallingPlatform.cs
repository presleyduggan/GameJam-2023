using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FallingPlatform : MonoBehaviour {
    [SerializeField]
    public float delay;
    [SerializeField]
    public float speed;
    [SerializeField]
    private bool startFall = false;
    private bool startDelay = false;


    private void Start() {
        
    }


    private void Update() {
        if(startDelay){
            StartCoroutine(wait());
        }
    }

    private void FixedUpdate() {
        if(startFall){
            transform.position += new Vector3(0, speed * Time.deltaTime * -1, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            // start the fall
            other.transform.SetParent(transform);
            startDelay = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(delay);
        startFall = true;
    }

}