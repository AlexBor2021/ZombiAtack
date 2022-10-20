using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Collider _triger;
    [SerializeField] private Coin _coin;
    [SerializeField] private Almaz _almaz;
    
    private int _health = 15;
    private int _revardCoin = 1;
    private int _revardAlmaz = 1;

    public int Health => _health; 
    public int RevardCoin => _revardCoin;
    public int RewardAlmaz => _revardAlmaz;

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
        if (_health <= 0)
            Die();
    }
    private void Die()
    {
        _coin.gameObject.SetActive(true);
        _almaz.gameObject.SetActive(_almaz.Probability());
        _navMeshAgent.speed = 0;
        _triger.enabled = false;
        _enemyAnimation.SetDie();
        DiedEnemy?.Invoke(this);
        Destroy(gameObject, 2f);
    }
}
