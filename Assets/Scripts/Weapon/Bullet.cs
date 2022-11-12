using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Bullet : MonoBehaviour
{
    [SerializeField] protected ParticleSystem _hitBulletWall;
    [SerializeField] protected int _damage = 1;
    
    protected float _speed = 20;
    
    private void Update()
    {
        transform.Translate(0, 0, -1 * _speed * Time.deltaTime);
        Destroy(gameObject, 0.7f);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            TakeDamage(enemy);
        }
        if (other.gameObject.name == "Wall")
        {
            Instantiate(_hitBulletWall, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    protected virtual void TakeDamage(Enemy enemy)
    {
        enemy.TakeDamage(_damage);
        Destroy(gameObject);
    }
}
