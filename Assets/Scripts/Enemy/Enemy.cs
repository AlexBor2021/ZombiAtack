using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private BoxCollider _triger;

    private int _health = 10;
    
    public int _revardCoin = 2;
    public int _revardAlmaz = 2;

    public int Health => _health;

    public event UnityAction<Enemy> DiedEnemy;

    public void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            _health -= damage;
            _enemyAnimation.SetHit();
        }
    }
        private void Die()
        {
            _triger.enabled = false;
            _enemyAnimation.SetDie();
            DiedEnemy?.Invoke(this);
            Destroy(gameObject, 2f);
        }
}
