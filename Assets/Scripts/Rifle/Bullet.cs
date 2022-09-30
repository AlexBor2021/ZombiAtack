using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLive;
    [SerializeField] private Rigidbody _rigibody;
    
    private int _damage = 1;
    private Enemy _enemy;

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out _enemy))
        {
            _enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
