using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    
    private Enemy _enemyTarget;

    private void Update()
    {
        if (_enemyTarget != null)
        {
            if (Vector3.Distance(_enemyTarget.transform.position, transform.position) < _rifle.RangeBullet)
            {
                transform.LookAt(_enemyTarget.transform.position);
                _rifle.ShootInEnemy(_enemyTarget);
            }
            else
            {
                _rifle.StopShoot();
            }
        }
        else
        {
            _rifle.StopShoot();
        }
    }

    public void SetEnemyTarget(Enemy enemyTarget)
    {
        _enemyTarget = enemyTarget;
    }
}
