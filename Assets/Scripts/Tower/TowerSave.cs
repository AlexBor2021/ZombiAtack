using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSave : MonoBehaviour
{
    [SerializeField] private UpgradeTower _upgradeTower;
    [SerializeField] private UnlockTower _unlockTower;

    private int _levelTower;

    public int LevelTower => _levelTower;

    public void Initialise(int levelData)
    {
        _levelTower = levelData;
        if (_levelTower > 0)
        {
            _unlockTower.Unlock();
            _upgradeTower.SetDataTower(_levelTower);
        }
    }
    public void TakeLevelTower(int levelUpgradeTower)
    {
        _levelTower = levelUpgradeTower;
    }
}
