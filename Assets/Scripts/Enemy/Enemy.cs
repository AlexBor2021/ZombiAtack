using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private EnemyMove _enemyMove;

    private int _health = 10;

    public int Health => _health;

    public event UnityAction<Enemy> DiedEnemy;

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            DiedEnemy?.Invoke(this);
            Destroy(gameObject, 2f);
        }
        else
        {
            _health -= damage;
            _enemyAnimation.SetHit();
        }
    }
}
