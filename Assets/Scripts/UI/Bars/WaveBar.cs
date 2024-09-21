using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberWave;
    [SerializeField] private EnemySpawn _enemySpawn;

    private void Update()
    {
        SetNumberWave(_enemySpawn.CurrentWaveNumber);
    }
    private void SetNumberWave(int number)
    {
        _numberWave.text = number.ToString();
    }
}
