using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private int _health = 40;

    public event UnityAction<Enemy> DiedEnemy;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            DiedEnemy?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
