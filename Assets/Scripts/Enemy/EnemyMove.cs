using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private Destructible _destructible;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private TargetsForEnemy _targetsForEnemy;
    private GameObject _target;
    
    public bool StopMoveTriger = false;

    private void Awake()
    {
        _targetsForEnemy = transform.parent.GetComponent<TargetsForEnemy>();
        _target = _targetsForEnemy.CurrentTarget;
    }

    private void Update()
    {
        if(_destructible.Health <= 0)
            return;
        if (_target == null)
            return;
        
        _target = _targetsForEnemy.CurrentTarget;

        if (StopMoveTriger == false )
        {
            _navMeshAgent.isStopped = false;
            _enemyAnimation.SetAtackAndMove(false);
            _navMeshAgent.SetDestination(_target.transform.position);
        }
        else
        {
            _navMeshAgent.isStopped = true;
            _enemyAnimation.SetAtackAndMove(true);
        }
    }
}
