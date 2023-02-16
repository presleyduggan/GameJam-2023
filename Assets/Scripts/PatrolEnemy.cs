using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;

    bool once;

    [SerializeField]
    private bool facingRight = true;

    private void Update()
    {

        switch(facingRight){
            case true:
                if(transform.position.x > patrolPoints[currentPointIndex].position.x){
                    transform.eulerAngles = new Vector3(0,0,0);
                } else{
                    transform.eulerAngles = new Vector3(0,180,0);
                }
                break;
            default:
                if(transform.position.x > patrolPoints[currentPointIndex].position.x){
                    transform.eulerAngles = new Vector3(0,180,0);
                } else{
                    transform.eulerAngles = new Vector3(0,0,0);
                }
                break;
        }



        if (transform.position != patrolPoints[currentPointIndex].position)
        {       
            transform.position = Vector2.MoveTowards(transform.position,patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        } else
        {
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
        {
            currentPointIndex++;
        } else 
        {
            currentPointIndex = 0;
        }
        once = false;
    }
}
