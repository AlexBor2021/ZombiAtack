using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    private Rigidbody _rb;
    private Transform _startPosition;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        int number = Random.Range(100, 400);
        _rb.AddForce(-Vector3.right * number);
    }
}
