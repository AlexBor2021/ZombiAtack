using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _health = 30;
    private float _healthForPErsent;
    private const string _up = "Up";
    private const string _midle = "Midle";
    private const string _down = "Down";

    public int Health => _health;

    private void OnEnable()
    {
        _healthForPErsent = _health;
    }

    private void Update()
    {
        if (_health <= SetPersent(_healthForPErsent, 65))
        {
            _animator.SetBool(_up, true);
        }
        if (_health <= SetPersent(_healthForPErsent, 35))
        {
            _animator.SetBool(_midle, true);
        }
        if(_health <= SetPersent(_healthForPErsent, 5))
        {
            _animator.SetBool(_down, true);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private float SetPersent(float number, float persentCurent)
    {
        float persent = number / 100 * persentCurent;
        return persent;
    }
}
