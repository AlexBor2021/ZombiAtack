using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetForPlayer : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private ShootingPlayer _shootingPlayer;
    [SerializeField] private Player _player;

    private Enemy _cuurentTarget;

    private void Update()
    {
        if (_enemies.Count == 0)
            return;
        foreach (var enemy in _enemies)
        {
            if (_cuurentTarget != null)
            {
                if (Vector3.Distance(_cuurentTarget.transform.position, transform.position) > Vector3.Distance(enemy.transform.position, transform.position))
                {
                    _cuurentTarget = enemy;
                }
            }
            else
            {
                _cuurentTarget = enemy;
            }
        }
        _shootingPlayer._enemyTarget = _cuurentTarget;
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.DiedEnemy += OnDieEnemy;
    }

    private void OnDieEnemy(Enemy enemy)
    {
        enemy.DiedEnemy -= OnDieEnemy;
        _enemies.Remove(enemy);
    }
}
