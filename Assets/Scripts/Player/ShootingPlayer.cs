using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    
    public Enemy EnemyTarget;

    private void Update()
    {
        if (EnemyTarget?.Health > 0)
        {
            if (Vector3.Distance(EnemyTarget.transform.position, transform.position) < _rifle.RangeBullet)
            {
                transform.LookAt(EnemyTarget.transform.position);
                _rifle.ShootInEnemy(EnemyTarget);
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
}
