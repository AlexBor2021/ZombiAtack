using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _health = 30;
    private const string _up = "Up";
    private const string _midle = "Midle";
    private const string _down = "Down";

    private void Update()
    {
        if (_health <= 21)
        {
            _animator.SetBool(_up, true);
        }
        if (_health <= 10)
        {
            _animator.SetBool(_midle, true);
        }
        if(_health <= 6)
        {
            _animator.SetBool(_down, true);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
