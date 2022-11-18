using System;
using System.Collections.Generic;

[Serializable]
public class BasaData
{
    public UnitData PlayerData;
    public ShopOnScene DataShopOnScene;
    public ShopUI ShopUI;
    public TowerPlace FirstTowerPlace;
    public TowerPlace SecondTowerPlace;
    public TowerPlace ThirdTowerPlace;
    
    public int CurrentWave = 0;

    public BasaData()
    {
        PlayerData = new UnitData();
        DataShopOnScene = new ShopOnScene();
        FirstTowerPlace = new TowerPlace();
        SecondTowerPlace = new TowerPlace();
        ThirdTowerPlace = new TowerPlace();
        ShopUI = new ShopUI();
    }
}

[Serializable]
public class ShopOnScene
{
    public int LevelDoor = 0;
    public int LevelHealthPlayer = 0;
}

[Serializable]
public class ShopUI
{
    public List<bool> SkinBuys = new List<bool>();
    public List<bool> WeaponBuys = new List<bool>();
}

[Serializable]
public class UnitData
{
    public int Coin = 1000;
    public int Almaz = 1000;
}


[Serializable]
public class TowerPlace
{
    public bool UnloockTower = false;
    public int LevelTower = 0;
}




