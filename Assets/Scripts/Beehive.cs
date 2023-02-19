using UnityEngine;
using System.Collections;

public class Beehive : MonoBehaviour {

    private Animator animator;
    public GameObject beePrefab;

    [SerializeField]
    private float delay;

    [SerializeField]
    private bool beesInNest = true;

    [SerializeField]
    private GameObject player;

    private void Start() {
        animator = GetComponent<Animator>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0];
    }

    private void Update() {
        if(player.GetComponent<Player>().health <= 0){
            // respawn the hive
            beesInNest = true;
            animator.SetBool("playerHere", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("something entered and beesinnest = "+beesInNest);
        if(other.gameObject.tag == "Player" && beesInNest){
            animator.SetBool("playerHere", true);
            beesInNest = false;
            StartCoroutine(spawnBees());
            // spawn bee


        }
    }


    private IEnumerator spawnBees(){
        yield return new WaitForSecondsRealtime(delay);
        Instantiate(beePrefab, transform.position, transform.rotation);
        
    }


}