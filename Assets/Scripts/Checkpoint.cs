using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private GameManager gm;
    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        gm.updateRespawnPoint(transform);
    }
}