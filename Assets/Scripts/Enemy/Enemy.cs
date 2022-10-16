using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private BoxCollider _triger;
    [SerializeField] private Coin _coin;
    [SerializeField] private Almaz _almaz;
    [SerializeField] private Destructible _destructible;
    
    private int _revardCoin = 1;
    private int _revardAlmaz = 1;
  
    public int RevardCoin => _revardCoin;
    public int RewardAlmaz => _revardAlmaz;

    public event UnityAction<Enemy> DiedEnemy;

    public void TakeDamage(int damage)
    {
        if (_destructible.Health <= 0)
        {
            Die();
        }
        else
        {
            _destructible.TakeDamage(damage);
            _enemyAnimation.SetHit();
        }
        if (_destructible.Health <= 0)
            Die();
    }
    private void Die()
    {
        _coin.gameObject.SetActive(true);
        _almaz.gameObject.SetActive(_almaz.Probability());
        _triger.enabled = false;
        _enemyAnimation.SetDie();
        DiedEnemy?.Invoke(this);
        Destroy(gameObject, 2f);
    }
}
