using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    [SerializeField]
    private float timer = 10;

    void Start() {
        rb.velocity = transform.right *  speed;
    }

    private void Update() {
        if(timer <= 0){
            Destroy(gameObject);
        }
        
        timer = timer - Time.deltaTime;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
       
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null && hitInfo.gameObject.tag != "Player")
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        } 
    }

}
