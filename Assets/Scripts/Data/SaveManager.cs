using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private DoorHealthUpgrade _doorHealthUpgrade;
    [SerializeField] private TowerSave _towerSave;
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private FinishWave _finishWave;

    private BasaData _basaData;

    public BasaData Data => _basaData;

    private void Awake()
    {
        _basaData = FindObjectOfType<YandexSDKInshilize>().BaseData;
        Initialise();
    }
    private void OnEnable()
    {
        _finishWave.FinishedWave += Save;
        _player.DiedPlayer += RestartPlayerCoinAndAlmaz;
    }
    private void OnDisable()
    {
        _finishWave.FinishedWave -= Save;
        _player.DiedPlayer -= RestartPlayerCoinAndAlmaz;
    }
    
    public void Initialise()
    {
        _player.Initialise(_basaData.PlayerData.Coin, _basaData.PlayerData.Almaz);
        _doorHealthUpgrade.Currentlevel = _basaData.DataShop.LevelDoor;
        _towerSave.Initialise(_basaData.NumberLevelTower);
        _enemySpawn.Initialise(_basaData.CurrentWave);
    }
    
    public void CollectInfo()
    {
        _basaData.PlayerData.Coin = _player.Coin;
        _basaData.PlayerData.Almaz = _player.Almaz;
        _basaData.DataShop.LevelDoor = _doorHealthUpgrade.Currentlevel;
        _basaData.NumberLevelTower = _towerSave.LevelTower;
        _basaData.CurrentWave = _enemySpawn.CurrentWaveNumber;
    }
    public void Save()
    {
        CollectInfo();
        string BasaData = JsonUtility.ToJson(_basaData);
#if UNITY_WEBGL && !UNITY_EDITOR 
        PlayerAccount.SetPlayerData(BasaData);
#endif
        Debug.Log(BasaData);
    }

    private void RestartPlayerCoinAndAlmaz()
    {
        _player.Initialise(_basaData.PlayerData.Coin, _basaData.PlayerData.Almaz);
    }
}
