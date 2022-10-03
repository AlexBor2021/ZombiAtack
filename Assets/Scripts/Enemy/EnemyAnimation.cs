using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string _hit = "Hit";
    private const string _die = "Die";

    public void SetHit()
    {
        _animator.SetTrigger(_hit);
    }

    public void SetDie()
    {
        _animator.SetTrigger(_die);
    }
}
