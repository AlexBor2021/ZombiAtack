using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class FinishWave : MonoBehaviour
{
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ModeSwitchUI _barForAttacks;
    [SerializeField] private List<ParticleSystem> _effects;

    public event UnityAction FinishedWave;

    public void FihishingWave(int diedEnemies)
    {
        if (_enemySpawn.CountEnemyInWave == diedEnemies)
        {
            FinishedWave?.Invoke();
            _text.gameObject.SetActive(true);
            _barForAttacks.SetUIShop();
            Invoke("OffText", 3);
            foreach (var effect in _effects)
            {
                effect.gameObject.SetActive(true);
            }
        }
    }
    public void OffText()
    {
        foreach (var effect in _effects)
        {
            effect.gameObject.SetActive(false);
        }
        _text.gameObject.SetActive(false);
    }
}

