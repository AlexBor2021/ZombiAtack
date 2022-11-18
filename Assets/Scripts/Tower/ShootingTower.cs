using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    [SerializeField] private Transform _rifleNavigation;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _maxrange;
    [SerializeField] private float _minrange;

    private Enemy _targetCurrent;

    private void Update()
    {

        if (_targetCurrent != null && _targetCurrent.Health > 0)
        {
            if (Vector3.Distance(_targetCurrent.transform.position, _shooter.transform.position) < _maxrange && Vector3.Distance(_targetCurrent.transform.position, _shooter.transform.position) > _minrange)
            {
                _rifle.ShootInEnemy(_targetCurrent);
                _shooter.LookOnTraget(_targetCurrent);
                _rifleNavigation.LookAt(_targetCurrent.transform, Vector3.up * 5f * Time.deltaTime);
            }
            else
            {
                _targetCurrent = null;
            }
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
            if (enemy.Health > 0 && _targetCurrent?.Health < 0 || _targetCurrent == null)
            {
                if (Vector3.Distance(enemy.transform.position, _shooter.transform.position) < _maxrange && Vector3.Distance(enemy.transform.position, _shooter.transform.position) > _minrange)
                {
                    SetTarget(enemy);
                }
            }
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
        if(_targetCurrent == null || _targetCurrent.Health <= 0)
        {
            _targetCurrent = enemy;
        }
    }
}
