using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Animator animator;

    private bool isFiring = false;

    private float fireDelay = 1f;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetButtonDown("Fire1") && !isFiring)
        {
            isFiring = true;
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(fireDelay);



        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("fire test");
    }
    
}
