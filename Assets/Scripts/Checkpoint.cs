using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private GameManager gm;
    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        gm.updateRespawnPoint(transform);
    }
}