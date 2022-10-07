using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animatorSkelet;
    [SerializeField] private Animator _animatorStickmen;

    private const string _hit = "Hit";
    private const string _die = "Die";
    private const string _atack = "Atack";

    public void SetHit()
    {
        _animatorStickmen.SetTrigger(_hit);
    }

    public void SetDie()
    {
        _animatorSkelet.SetTrigger(_die);
        _animatorStickmen.SetTrigger(_die);
    }

    public void SetAtack(bool conditionAtack)
    {
        _animatorSkelet.SetBool(_atack, conditionAtack);
    }
}
