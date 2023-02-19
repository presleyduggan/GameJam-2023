using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Cloud : Enemy {
    
    [SerializeField]
    private List<Transform> beams = new List<Transform>();

    private int currentTrigger = 0;

    [SerializeField]
    private float cloudTimer;

    public AudioSource boom;

    private Animator animator;

    //private CloudManager cloud;

    private float cloudTimerReset;

    private bool isAttacked = false;

    private bool isEnraged = false;

    public AudioSource enrage;

    private void Start() {
        for(int i = 0; i<3; i++){
            beams.Add(this.gameObject.transform.GetChild(i));
        }
        animator = GetComponent<Animator>();
        cloudTimerReset = cloudTimer;
       // cloud = FindObjectOfType<CloudManager>();
    }

    private void Update() {
        if(cloudTimer > 0){
            cloudTimer -= Time.deltaTime;
        }
        else{
            if(health > 375)
                StartCoroutine(activateBeam());
            else {
                cloudTimerReset = cloudTimerReset/2;
                animator.SetBool("phaseTwo", true);
                StartCoroutine(activateBeams());
            }
        }
    }

    public void updateTrigger(int trigger){
        Debug.Log("updating current trigger to "+trigger);
        currentTrigger = trigger;

    }

    public override void TakeDamage (int damage)
    {

      //  Debug.Log("taking damage of "+damage);

        health -= damage;

        

        if (health <= 0)
        {
         //   Debug.Log("killing player");
            Die();
            
        } else{

        // change color
        if(!isAttacked)
        StartCoroutine(changeColor());
        }
    }

    public override void Die()
    {
        cloudTimer = 1000000f;
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.black);
    }

    public IEnumerator activateBeam(){
        cloudTimer = 1000f;
        Transform beam = beams[currentTrigger];
        beam.gameObject.SetActive(true);
        Animator animator = beam.gameObject.GetComponent<Animator>();
        //StartCoroutine(wait());
       // Debug.Log("waiting for 1...");
        //yield return new WaitForSeconds(3f);

        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength - 0.50f);

        Transform laser = beam.GetChild(0);
        boom.Play();
        laser.gameObject.SetActive(true);
        //StartCoroutine(wait());
       // Debug.Log("waiting for 2...");
        yield return new WaitForSeconds(3f);
       // Debug.Log("done?");

        cloudTimer = cloudTimerReset;
        beam.gameObject.SetActive(false);
        laser.gameObject.SetActive(false);
    }

    public IEnumerator activateBeams(){

        if(!isEnraged){
            isEnraged = true;
            enrage.Play();
        }

        cloudTimer = 1000f;
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);
        Transform beam = beams[currentTrigger];
        Animator animator = beam.gameObject.GetComponent<Animator>();
        Transform beam2 = beams[generateRandomBeam(currentTrigger)];
        beam.gameObject.SetActive(true);
        beam2.gameObject.SetActive(true);
        //StartCoroutine(wait());
       // Debug.Log("waiting for 1...");
        //yield return new WaitForSeconds(3f);
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength - 0.50f);

        Transform laser = beam.GetChild(0);
        Transform laser2 = beam2.GetChild(0);
        laser.gameObject.SetActive(true);
        laser2.gameObject.SetActive(true);
        boom.Play();
        //StartCoroutine(wait());
       // Debug.Log("waiting for 2...");
        yield return new WaitForSeconds(3f);
       // Debug.Log("done?");

        cloudTimer = cloudTimerReset;
        beam.gameObject.SetActive(false);
        beam2.gameObject.SetActive(false);
        laser.gameObject.SetActive(false);
        laser2.gameObject.SetActive(false);
    }

    IEnumerator wait(){
      //  Debug.Log("test1234");
        yield return new WaitForSeconds(3f);
    }

    private int generateRandomBeam(int trigger){
        List<int> nums = new List<int>();
        for(int i = 0; i<3; i++){
            if(trigger != i)
                nums.Add(i);
        }

        int rand = Random.Range(0,2);
        return nums[rand];

    }


    public override IEnumerator changeColor(){

        isAttacked = true;

        if(health > 250){
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);

        yield return new WaitForSecondsRealtime(.5f);

        //if(health > 250)
        renderer.material.SetColor("_Color", Color.white);
        } else{
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.gray);

        yield return new WaitForSecondsRealtime(.5f);

        //if(health > 250)
        renderer.material.SetColor("_Color", Color.red);
        }

        isAttacked = false;
        //renderer.sortingLayerID = SortingLayer.NameToID("Weapons");
    }


}