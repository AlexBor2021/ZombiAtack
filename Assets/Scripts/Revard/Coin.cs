using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Revard _revard;
    [SerializeField] private Enemy _enemy;

    private int _value;

    public int Value => _value;

    private void Awake()
    {
        _value = _enemy.RevardCoin;
    }
    
}
