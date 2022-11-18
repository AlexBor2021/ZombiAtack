using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinSeller : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _cost;
    [SerializeField] private TextMeshProUGUI _textCost;
    [SerializeField] private SkinInstaller _skinInstaller;
    
    private bool _isBuy = false;

    public bool IsBuy => _isBuy;

    private void Awake()
    {
        _textCost.text = _cost.ToString();
    }
    private void Update()
    {
        if (_player.Almaz >= _cost)
        {
            _textCost.color = Color.white;
        }
        else
        {
            _textCost.color = Color.red;
        }
    }
    public void BuySkin()
    {
        if (_player.Almaz >= _cost)
        {
            _isBuy = true;
            _player.GiveAlmaz(_cost);
            _skinInstaller.ActiveButton();
        }
    }
    public void DataSkinSeller(bool isBuy)
    {
        if (isBuy)
        {
            _isBuy = true;
            _skinInstaller.ActiveButton();
        }
    }
}
