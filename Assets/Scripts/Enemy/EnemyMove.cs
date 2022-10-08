using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speed;

    private TargetsForEnemy _targetsForEnemy;
    private GameObject _target;
    public bool StopMoveTriger = false;

    private void OnEnable()
    {
        _targetsForEnemy = transform.parent.GetComponent<TargetsForEnemy>();
        _target = _targetsForEnemy.CurrentTarget;
    }

    private void Update()
    {
        if(_enemy.Health <= 0)
            return;
        if (_target == null)
            return;
        
        _target = _targetsForEnemy.CurrentTarget;

        if (StopMoveTriger == false)
        {
            _enemyAnimation.SetAtackAndMove(false);
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            _enemyAnimation.SetAtackAndMove(true);
        }
        transform.LookAt(_target.transform);
    }
}
