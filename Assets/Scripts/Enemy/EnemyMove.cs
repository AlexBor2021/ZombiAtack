using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private float _speed;

    private TargetsForEnemy _targetsForEnemy;
    private GameObject _target;

    private void OnEnable()
    {
        _targetsForEnemy = transform.parent.GetComponent<TargetsForEnemy>();
        _target = _targetsForEnemy.CurrentTarget;
    }

    private void Update()
    {
        if (_target == null)
            return;
        if (Vector3.Distance(transform.position, _target.transform.position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        }
        else
        {
            _enemyAnimation.SetAtack(true);
        }
        transform.rotation = Quaternion.LookRotation(-_target.transform.position);
    }
}
