using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLive;
    private float _time;
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _time += Time.deltaTime;
        if (_time >= _timeLive)
        {
            Destroy(gameObject);
        }
    }
}
