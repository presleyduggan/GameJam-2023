using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Animator animator;

    private bool isFiring = false;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetButtonDown("Fire1") && !isFiring)
        {
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot ()
    {



        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Debug.Log("fire test");
    }
    
}
