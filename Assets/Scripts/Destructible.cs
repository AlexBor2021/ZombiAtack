using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _maxHealth;
    public int MaxHealth => _maxHealth;
    public int Health => _health;

    private void OnEnable()
    {
        _maxHealth = _health;
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
    public void RecoveryHealth()
    {
        _health = _maxHealth;
    }
    public void UpgradeHealth(int health)
    {
        _maxHealth += health;
        RecoveryHealth();
    }
}
