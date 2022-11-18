using UnityEngine;

public class TowerPlaceData : MonoBehaviour
{
    [SerializeField] private UnlockTower _unlockTower;
    [SerializeField] private UpgradeTower _upgradeTower;

    private bool _isUnlockTower = false;
    private int _levelTower;

    public bool IsUnlockTower => _isUnlockTower;
    public int LevelTower => _levelTower;

    public void Initialize(int levelTower, bool isUnlockTower)
    {
        _levelTower = levelTower;
        _isUnlockTower = isUnlockTower;
        if (_isUnlockTower)
        {
            _unlockTower.UnlockData();
        }
        if(_levelTower > 0)
        {
            _upgradeTower.SetDataTower(_levelTower);
        }
    }

    public void AskLevelTower(int levelTower)
    {
        _levelTower = levelTower;
    }
    public void AskIsUnlockTowerTower(bool isUnlockTower)
    {
        _isUnlockTower = isUnlockTower;
    }
}
