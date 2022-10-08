using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private float _speed = 15;
    private int _damage = 1;

    private void OnEnable()
    {
        transform.parent = null;
        _effect.Play();
    }

    private void Update()
    {
        transform.Translate(1 * _speed * Time.deltaTime, 0, 0);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);    
        }
    }
}
