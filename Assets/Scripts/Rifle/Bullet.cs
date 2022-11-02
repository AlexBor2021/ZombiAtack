using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _hitBullet;

    private float _speed = 25;
    private int _startDamage;

    private void OnEnable()
    {
        _startDamage = _damage;
    }
    private void OnDisable()
    {
        _damage = _startDamage;
    }
    private void Update()
    {
        transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Wall" || collision.gameObject.name == "Table")
        {
            Instantiate(_hitBullet, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Updamage(int updamage)
    {
        _damage += updamage;
    }
}
