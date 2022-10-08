using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] private List<Wave> _waves;
    [SerializeField] private TargetForPlayer _targetForPlayer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BarDie _barDie;
    
    private Wave _currentWave;
    private float _timeAfterLastSpawn;
    private int _spawnedEnemy;

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

    private void InstatietEnemy()
    {
        var enemy = Instantiate(_currentWave.Enemy, _spawnPoint.transform.position, _spawnPoint.transform.rotation, transform).GetComponent<Enemy>();
        _targetForPlayer.AddEnemy(enemy);
        enemy.DiedEnemy += _barDie.SetCountDie;
    }
    

    [System.Serializable]

    public class Wave
    {
        public GameObject Enemy;
        public float Delya;
        public int CountEnemy;
    }
}
