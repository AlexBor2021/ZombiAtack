using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private EnemyAnimation _enemyAnimation;

    private Destructible _destructible;
    private int _damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _destructible = destructible;
            Attack(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _destructible = null;
            Attack(false);
        }
    }
    private void GiveDamage()
    {
        if (_destructible.Health > 0 && _destructible != null)
        {
            _destructible.TakeDamage(_damage);
        }
        else
        {
            Attack(false);
        }
    }
    private void Attack(bool work)
    {
        _enemyMove.StopMoveTriger = work;
        _enemyAnimation.SetAtackAndMove(work);
    }
}
