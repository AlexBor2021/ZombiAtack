using UnityEngine;

public class DataShopInScene : MonoBehaviour
{
    [SerializeField] private DoorHealthUpgrade _doorHealthUpgrade;
    [SerializeField] private UpgradeHealrh _upgradeHealrh;

    private int _levelDoor;
    private int _levelHealth;

    public int LevelDoor => _levelDoor;
    public int LevelHealth => _levelHealth;

    public void Initialize(int levelDoor, int levelHealth)
    {
        _levelDoor = levelDoor;
        _levelHealth = levelHealth;

        _upgradeHealrh.UpgradeHealthData(_levelHealth);
        _doorHealthUpgrade.UpgradeDoorData(_levelDoor);
    }

    public void AskLevelHealth(int levelHralth)
    {
        _levelHealth = levelHralth;
    }
    public void AskLevelDoor(int levelDoor)
    {
        _levelDoor = levelDoor;
    }
}
