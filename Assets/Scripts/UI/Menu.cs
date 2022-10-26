using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private ModeSwitchUI _barForAttacks;
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private BarDie _barDie;
    [SerializeField] private AllDoorRestart _allDoorRestart;

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
        _allDoorRestart.RestartDoor();
        _player.Restart();
        _barDie.Restart();
        var enemeis = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in enemeis)
        {
            Destroy(enemy);
        }
        _enemySpawn.Restart();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
