using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingPlayer : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Destructible _player;
    
    public Enemy EnemyTarget;

    private void Update()
    {
        if (EnemyTarget?.Health > 0 && _player.Health > 0)
        {
            if (Vector3.Distance(EnemyTarget.transform.position, transform.position) < _weapon.RangeBullet)
            {
                transform.LookAt(EnemyTarget.transform.position);
                _weapon.ShootInEnemy(EnemyTarget);
            }
            else
            {
                _weapon.StopShoot();
            }
        }
        else
        {
            _weapon.StopShoot();
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
}
