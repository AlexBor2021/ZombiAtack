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
        _startPosition = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        transform.position = _startPosition.position;
        transform.rotation = _startPosition.rotation;
        int number = Random.Range(800, 1300);
        _rb.AddForce(-Vector3.right * number);
    }
}
