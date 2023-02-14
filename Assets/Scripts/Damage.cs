using UnityEngine;

public class Damage : MonoBehaviour {
    public int damage;

    private int count;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(count == 0)
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            count--;
        }
    }

}