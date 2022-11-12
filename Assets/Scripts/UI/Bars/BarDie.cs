using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarDie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDie;
    [SerializeField] private FinishWave _finishWave;
    [SerializeField] private EnemySpawn _enemySpawn;

    private int _countDie = 0;

    private void OnEnable()
    {
        _textDie.text = _countDie.ToString();
    }
    private void OnDisable()
    {
        Restart();
    }
    public void SetCountDie(Enemy enemy)
    {
        enemy.DiedEnemy -= SetCountDie;
        _countDie++;
        _textDie.text = _countDie.ToString();
        if (_enemySpawn.CountEnemyInWave == _countDie)
        {
            _finishWave.gameObject.SetActive(true);
        }
    }
    public void Restart()
    {
        _countDie = 0;
        _textDie.text = _countDie.ToString();
    }
}
