using UnityEngine;
using Agava.YandexGames;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TowerPlaceData _firstTowerPlaceData;
    [SerializeField] private TowerPlaceData _secondTowerPlaceData;
    [SerializeField] private TowerPlaceData _thirdTowerPlaceData;
    [SerializeField] private DataShopInScene _dataShopInScene;
    [SerializeField] private DataShopUI _dataShopUI;
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private FinishWave _finishWave;

    private BasaData _basaData;

    public BasaData Data => _basaData;
    public const string LeaderBoardName = "WaveCount";

    private void Awake()
    {
        _basaData = new BasaData();
        Initialise();
    }
    private void OnEnable()
    {
        //Leaderboard.SetScore(LeaderBoardName, _enemySpawn.CurrentWaveNumber);
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
       
        _firstTowerPlaceData.Initialize(_basaData.FirstTowerPlace.LevelTower, _basaData.FirstTowerPlace.UnloockTower);
       
        _secondTowerPlaceData.Initialize(_basaData.SecondTowerPlace.LevelTower, _basaData.SecondTowerPlace.UnloockTower);
       
        _thirdTowerPlaceData.Initialize(_basaData.ThirdTowerPlace.LevelTower, _basaData.ThirdTowerPlace.UnloockTower);
        
        _dataShopInScene.Initialize(_basaData.DataShopOnScene.LevelDoor, _basaData.DataShopOnScene.LevelHealthPlayer);
        
        _dataShopUI.Initialize(_basaData);

        _enemySpawn.Initialise(_basaData.CurrentWave);
    }
    
    public void CollectInfo()
    {
        _basaData.PlayerData.Coin = _player.Coin;
        _basaData.PlayerData.Almaz = _player.Almaz;

        _basaData.FirstTowerPlace.LevelTower = _firstTowerPlaceData.LevelTower;
        _basaData.FirstTowerPlace.UnloockTower = _firstTowerPlaceData.IsUnlockTower;

        _basaData.SecondTowerPlace.LevelTower = _secondTowerPlaceData.LevelTower;
        _basaData.SecondTowerPlace.UnloockTower = _secondTowerPlaceData.IsUnlockTower;

        _basaData.ThirdTowerPlace.LevelTower = _thirdTowerPlaceData.LevelTower;
        _basaData.ThirdTowerPlace.UnloockTower = _thirdTowerPlaceData.IsUnlockTower;

        _basaData.DataShopOnScene.LevelDoor = _dataShopInScene.LevelDoor;
        _basaData.DataShopOnScene.LevelHealthPlayer = _dataShopInScene.LevelHealth;

        _basaData.CurrentWave = _enemySpawn.CurrentWaveNumber;

        _basaData.ShopUI = _dataShopUI.DataForShopUI.ShopUI;
    }
    public void Save()
    {
        CollectInfo();
        string BasaData = JsonUtility.ToJson(_basaData);
#if UNITY_WEBGL && !UNITY_EDITOR 
        Leaderboard.SetScore(LeaderBoardName, _enemySpawn.CurrentWaveNumber);
        PlayerAccount.SetPlayerData(BasaData);
        Debug.Log(BasaData);
#endif
        Debug.Log(BasaData);
    }

    private void RestartPlayerCoinAndAlmaz()
    {
        _player.Initialise(_basaData.PlayerData.Coin, _basaData.PlayerData.Almaz);
    }

    public void PlayAgain()
    {
        _basaData = new BasaData();
        Initialise();
        //Leaderboard.SetScore(LeaderBoardName, _enemySpawn.CurrentWaveNumber);
    }
}
