using UnityEngine;

public class Mailbox : MonoBehaviour {

    public GameManager gm;
    private Animator animator;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            // end level
            animator.SetBool("endLevel", true);
            gm.endLevel();
        }
    }
}