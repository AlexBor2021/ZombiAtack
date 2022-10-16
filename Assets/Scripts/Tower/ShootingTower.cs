using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    [SerializeField] private Shooter _shooter;

    private Enemy _targetCurrent;

    private void Update()
    {
        if (_targetCurrent != null)
        {
            _shooter.LookOnTraget(_targetCurrent);
            _rifle.ShootInEnemy(_targetCurrent);
        }
        else
        {
            _rifle.StopShoot();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (enemy.GetComponent<Destructible>().Health > 0)
                SetTarget(enemy);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out Enemy enemy) == _targetCurrent)
        {
            _targetCurrent = null;
        }
    }
    private void SetTarget(Enemy enemy)
    {
        if(_targetCurrent == null)
        {
            _targetCurrent = enemy;
        }
        else if (_targetCurrent.GetComponent<Destructible>().Health <= 0)
        {
            _targetCurrent = enemy;
        }
    }
}
