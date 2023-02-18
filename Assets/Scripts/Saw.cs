using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Damage
{

    [SerializeField]
    private float rotateAmount = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateAmount*Time.deltaTime, Space.Self);
    }
}
