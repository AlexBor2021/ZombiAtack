using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RateRifleUpgrade : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private Player _player;
    [SerializeField] private Button _buyButton;

    private int _cost = 50;
    private int _levelNext = 2;
    private float _rate = 0.05f;
    private int _maxLevell = 5;
    private const string _max = "max";

    private void Awake()
    {
        _costText.text = _cost.ToString();
        _numberLevel.text = _levelNext.ToString();
    }
    private void Update()
    {
        if (_player.Coin >= _cost)
            _costText.color = Color.white;
        else
            _costText.color = Color.red;
    }
    public void UpgradeRifleRate()
    {
        if (_player.Coin >= _cost)
        {
            _costText.color = Color.white;
            _player.GiveCoin(_cost);
            _rifle.UpgradeRate(_rate);
            SetUI();
        }
    }
    private void SetUI()
    {
        _levelNext++;
        if (_levelNext <= _maxLevell)
        {
            _cost *= 2;
            _costText.text = _cost.ToString();
            _numberLevel.text = _levelNext.ToString();
        }
        else
        {
            _costText.text = _max.ToString();
            _buyButton.interactable = false;
        }
    }
}
