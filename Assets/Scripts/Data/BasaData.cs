using System;

[Serializable]
public class BasaData
{
    public UnitData PlayerData;
    public Shop DataShop;
    public int NumberLevelTower = 0;
    public int CurrentWave = 0;

    public BasaData()
    {
        PlayerData = new UnitData();
        DataShop = new Shop();
    }
}

[Serializable]
public class Shop
{
    public int LevelDoor = 1;
}

[Serializable]
public class UnitData
{
    public int Coin = 0;
    public int Almaz = 0;
}


