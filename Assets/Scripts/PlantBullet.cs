using UnityEngine;
using System.Collections.Generic;


public class PlantBullet : MonoBehaviour {
    public int damage;

    [SerializeField]
    private List<string> damageText = new List<string>();

    private int count;

    private GameObject target;

    private Vector3 spotInTime;


    public float speed;

    private void Start() {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        target = players[0];
        if(target == null){
            // player is dead..
            Destroy(gameObject);
        }

        spotInTime = target.transform.position;
    }


    private void Update() {
        //transform.position = Vector2.MoveTowards(transform.position, spotInTime, speed * Time.deltaTime);
        transform.position += transform.right* speed* Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
                string returnText = null;
                if(damageText.Count > 0){
                    returnText = returnRandomText();
                }
                other.gameObject.GetComponent<Player>().TakeDamage(damage, returnText);
        }

        Destroy(gameObject);
    }


    

    private string returnRandomText(){
        int rand = Random.Range(0,damageText.Count);
        return damageText[rand];
    }

}