using UnityEngine;

public class SprayFlowerZone : MonoBehaviour {

    private SprayFlower myFlower;

    private void Start() {
        myFlower = transform.parent.GetComponent<SprayFlower>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            myFlower.startSpray();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            myFlower.stopSpray();
        }
    }
}