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

    private void OnEnable()
    {
        _player.DiedPlayer += ClearList;
    }
    private void OnDisable()
    {
        _player.DiedPlayer -= ClearList;
    }
    private void Update()
    {
        if (_enemies.Count == 0)
            return;
        SetNextTarget();
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
        enemy.DiedEnemy += OnDieEnemy;
    }
    public void SetNextTarget()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.Health > 0)
            {
                if (_cuurentTarget == null || _cuurentTarget.Health <= 0 )
                {
                    _cuurentTarget = enemy;
                    _shootingPlayer.EnemyTarget = _cuurentTarget;
                }
                if (Vector3.Distance(_cuurentTarget.transform.position, transform.position) > Vector3.Distance(enemy.transform.position, transform.position))
                {
                    _cuurentTarget = enemy;
                }
            }
        }
        _shootingPlayer.EnemyTarget = _cuurentTarget;
    }
    private void OnDieEnemy(Enemy enemy)
    {
        enemy.DiedEnemy -= OnDieEnemy;
        _enemies.Remove(enemy);
    }
    private void ClearList()
    {
        _enemies.Clear();
    }
}
