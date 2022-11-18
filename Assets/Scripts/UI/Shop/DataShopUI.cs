using System.Collections.Generic;
using UnityEngine;

public class DataShopUI : MonoBehaviour
{
    [SerializeField] private List<SkinSeller> _skinSellers;
    [SerializeField] private List<SellerWeapon> _sellerWeapons;
    [SerializeField] private SaveManager _saveManager;

    private BasaData _dataForShopUI;

    public BasaData DataForShopUI => _dataForShopUI;

    private void OnDisable()
    {
        SaveInfo();
    }

    public void Initialize(BasaData basaData)
    {
        _dataForShopUI = basaData;
        
        if (_dataForShopUI.ShopUI.SkinBuys.Count > 0)
        {
            for (int i = 0; i < _skinSellers.Count; i++)
            {
                _skinSellers[i].DataSkinSeller(_dataForShopUI.ShopUI.SkinBuys[i]);
            }
        }
        if (_dataForShopUI.ShopUI.WeaponBuys.Count > 0)
        {
            for (int i = 0; i < _sellerWeapons.Count; i++)
            {
                _sellerWeapons[i].DataWeaponSeller(_dataForShopUI.ShopUI.WeaponBuys[i]);
            }
        }
    }
    private void SaveInfo()
    {
        for (int i = 0; i < _skinSellers.Count; i++)
        {
            _dataForShopUI.ShopUI.SkinBuys.Add(_skinSellers[i].IsBuy);
        }
        for (int i = 0; i < _sellerWeapons.Count; i++)
        {
            _dataForShopUI.ShopUI.WeaponBuys.Add(_sellerWeapons[i].IsBuy);
        }
    }
}
