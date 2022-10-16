using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private TargetForPlayer _targetForPlayer;
    [SerializeField] private BarDie _barDie;
    [SerializeField] private BarForAttacks _barForAttacks;
    
    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawnedEnemy;
    public int CurrentWaveNumber => _currentWaveNumber;
    public int CountEnemyInWave;

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
    public void NextWave()
    {
        _spawnedEnemy = 0;
        _currentWave = _waves[_currentWaveNumber];
        _currentWaveNumber++;
        _barForAttacks.SetUIAttack();
        CountEnemyInWave = _currentWave.CountEnemy;
    }
    private void InstatietEnemy()
    {
        foreach (var spawnPosition in _currentWave.Transforms)
        {
            var enemy = Instantiate(_currentWave.Enemy, spawnPosition).GetComponent<Enemy>();
            _targetForPlayer.AddEnemy(enemy);
            enemy.DiedEnemy += _barDie.SetCountDie;
        }
    }

    [System.Serializable]

    public class Wave
    {
        public GameObject Enemy;
        public float Delya;
        public int CountEnemy;
        public List<Transform> Transforms;
    }
}
