using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;
    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
