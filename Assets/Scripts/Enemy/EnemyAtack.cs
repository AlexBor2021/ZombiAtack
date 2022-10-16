using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;

    private TargetsForEnemy _targetsForEnemy;
    private Destructible _destructible;
    private Coroutine _giveDamage;
    private int _damage = 5;
    
    private void Awake()
    {
        _targetsForEnemy = transform.parent.GetComponent<TargetsForEnemy>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _destructible = destructible;
            if (_destructible.Health > 0)
            {
                _enemyMove.StopMoveTriger = true;
            }
            else
            {
                _enemyMove.StopMoveTriger = false;
                _targetsForEnemy.DestroyTarget();
            }    
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _destructible = null;
            _enemyMove.StopMoveTriger = false;
        }
    }

    public void GiveDamage()
    {
        _destructible.TakeDamage(_damage);
    }
}
