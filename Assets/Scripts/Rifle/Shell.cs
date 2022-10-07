using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _timeLive;

    private float _forseForShell = 10f;

    private void OnEnable()
    {
       transform.parent = null;
       GetComponent<Rigidbody>().AddForce(transform.position * _forseForShell);
    }

    private void Update()
    {
        Destroy(gameObject, _timeLive);
    }
}
