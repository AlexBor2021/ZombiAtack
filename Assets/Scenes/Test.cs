using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform test;

    void Update()
    {
        Vector3 diraction = test.position - transform.position;
        transform.LookAt(test, Vector3.up);
    }
}
