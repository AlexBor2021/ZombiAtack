using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private EnemyAnimation _enemyAnimation;

    private Destructible _destructible;
    private int _damage = 5;

    public void SetDestructible(Destructible destructible)
    {
        if (_destructible == null && destructible?.Health > 0)
        {
            _destructible = destructible;   
            Attack(true);
        }
    }
    public void ExitDestructible(Destructible destructible)
    {
        if (destructible == _destructible)
        {
            _destructible = null;
            Attack(false);
        }
    }
    private void GiveDamage()
    {
        if (_destructible?.Health > 0)
        {
            _destructible.TakeDamage(_damage);
        }
        else
        {
            _destructible = null;
            Attack(false);
        }
    }
    private void Attack(bool work)
    {
        _enemyMove.StopMoveTriger = work;
        _enemyAnimation.SetAtackAndMove(work);
    }
}
