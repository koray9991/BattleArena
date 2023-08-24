using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    public Transform target;
    public float xRot, yRot, zRot;

    private void Start()
    {
        target = transform.parent;
        transform.parent = GameObject.FindGameObjectWithTag("RangeObjects").transform;
    }
    private void FixedUpdate()
    {
        transform.position = target.transform.position;
        transform.Rotate(xRot, yRot, zRot);


    }
}
