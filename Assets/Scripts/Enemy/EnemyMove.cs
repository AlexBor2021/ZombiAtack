using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    private GameObject _target;
    public GameObject Target => _target;
    
    public bool StopMoveTriger = false;

    private void Update()
    {
        if (_target.GetComponent<Destructible>().Health <= 0)
        {
            Destroy(gameObject);
            return;
        }
        if (StopMoveTriger == false)
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.SetDestination(_target.transform.position);
        }
        else
        {
            _navMeshAgent.isStopped = true;
        }
    }
    public void SetTarget(GameObject player)
    {
        _target = player;
    }
}
