using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Almaz : MonoBehaviour
{
    [SerializeField] private Revard _revard;
    [SerializeField] private Enemy _enemy;

    private float _numberProability = 3;
    public int TakeAlmaz()
    {
        return _enemy.RewardAlmaz;
    }

    public bool Probability()
    {
        int number = Random.Range(0, 20);
        if (number == _numberProability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
