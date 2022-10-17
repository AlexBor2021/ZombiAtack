using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private BarForAttacks _barForAttacks;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private BarDie _barDie;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        if (_barDie.isActiveAndEnabled)
        {
            _enemySpawn.RestartWave();
            _barForAttacks.SetUIShop();
            _player.transform.position = _playerPosition.position;
        }
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
