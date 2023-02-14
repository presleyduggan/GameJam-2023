using UnityEngine;

public class CloudTrigger : MonoBehaviour {
    
    public int position;

    [SerializeField]
    private GameObject CloudBoss;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
            CloudBoss.GetComponent<Cloud>().updateTrigger(position);
    }


}