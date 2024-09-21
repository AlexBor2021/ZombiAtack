using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : Bullet
{
    [SerializeField] private int _damagePlusTower;

    protected override void TakeDamage(Enemy enemy)
    {
        _damagePlusTower += _damage;
        enemy.TakeDamage(_damagePlusTower);
        Destroy(gameObject);
    }
} 

