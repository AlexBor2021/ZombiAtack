using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ShootPlayer _shootPlayer;
    [SerializeField] private Rifle _rifle;

    private Wave _currentWave;
    private float _timeAfterLastSpawn;
    private int _spawnedEnemy;
    private Enemy _currentTargetForPlayer;

    private void OnEnable()
    {
        _currentWave = _waves[0];
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;
        if (_timeAfterLastSpawn >= _currentWave.Delya && _spawnedEnemy < _currentWave.CountEnemy)
        {
            InstatietEnemy();
            _spawnedEnemy++;
            _timeAfterLastSpawn = 0;
        }
    }

    private void SetTargetForEnemy(Enemy enemy)
    {
        foreach (var target in _targets)
        {
            enemy.GetComponent<EnemyMove>().GetTarget(target);
        }
    }

    private void InstatietEnemy()
    {
        var enemy = Instantiate(_currentWave.Enemy, _spawnPoint.transform.position, _spawnPoint.transform.rotation, transform).GetComponent<Enemy>();
        enemy.DiedEnemy += OnDieEnemy;
        _enemies.Add(enemy);
        _currentTargetForPlayer = enemy;
        SetTargetForEnemy(enemy);
        SetTargetForPlayer();
    }

    private void OnDieEnemy(Enemy enemy)
    {
        enemy.DiedEnemy -= OnDieEnemy;
        enemy.GetComponent<EnemyMove>().Die();
        enemy.GetComponent<EnemyAnimation>().SetDie();
        _enemies.Remove(enemy);
        SetTargetForPlayer();
    }

    private void SetTargetForPlayer()
    {
        _shootPlayer.SetEnemyTarget(_currentTargetForPlayer);

        foreach (var enemy in _enemies)
        {
            if (Vector3.Distance(enemy.transform.position, _shootPlayer.transform.position) < _rifle.RangeBullet)
            {
                _currentTargetForPlayer = enemy;
                _shootPlayer.SetEnemyTarget(_currentTargetForPlayer);
            }
        }
    }

    [System.Serializable]

    public class Wave
    {
        public GameObject Enemy;
        public float Delya;
        public int CountEnemy;
    }
}
