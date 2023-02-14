using UnityEngine;

public class Beam : Damage {
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}