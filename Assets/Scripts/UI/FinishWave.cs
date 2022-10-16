using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class FinishWave : MonoBehaviour
{
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private BarForAttacks _barForAttacks;

    public event UnityAction FinishedWave;

    public void FihishingWave(int diedEnemies)
    {
        if (_enemySpawn.CountEnemyInWave == diedEnemies)
        {
            FinishedWave?.Invoke();
            _text.gameObject.SetActive(true);
            _barForAttacks.SetUIShop();
            Invoke("OffText", 4);
        }
    }
    public void OffText()
    {
        _text.gameObject.SetActive(false);
    }
}

