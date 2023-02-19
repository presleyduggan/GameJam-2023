using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Animator animator;

    private bool isFiring = false;

    [SerializeField]
    private float fireDelay = 0.5f;

    public AnimationClip clip;

    [SerializeField]
    private bool canFire = true;


    private void Start() {
        animator = GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetButton("Fire1") && !isFiring && canFire)
        {
            isFiring = true;
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot()
    {
        // start animation
        animator.SetBool("isAttacking", true);

        //yield return new WaitForSecondsRealtime(0.1f);
        //float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        //float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSecondsRealtime(clip.length);

        animator.SetBool("isAttacking", false);
        

        //yield return new WaitForSeconds(fireDelay);



        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSecondsRealtime(fireDelay);
        isFiring = false;

    }


    public void playerCanFire(bool value){
        canFire = value;
    }
    
}
