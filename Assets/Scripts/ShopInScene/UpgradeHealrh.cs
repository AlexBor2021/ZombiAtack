using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeHealrh : MonoBehaviour
{
    [SerializeField] private Destructible _playerDestractible;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private List<Image> _stars;
    [SerializeField] private Player _player;
    [SerializeField] private Button _buyButton;

    private int _cost = 5;
    private int _health = 10;
    private int _levelNext = 0;
    private int _maxLevell = 5;
    private const string _max = "max";

    public int Currentlevel = 1;

    private void Awake()
    {
        _costText.text = _cost.ToString();
        _stars[_levelNext].enabled = true;
    }
    private void Update()
    {
        if (_player.Coin >= _cost)
            _costText.color = Color.white;
        else
            _costText.color = Color.red;
    }
    public void UpgradeHealth()
    {
        if (_player.Coin >= _cost)
        {
            _costText.color = Color.white;
            _player.GiveCoin(_cost);
            _playerDestractible.UpgradeHealth(_health);
            SetUI();
            Currentlevel++;
        }
        else
        {
            _costText.color = Color.red;
        }
    }
    private void SetUI()
    {
        _levelNext++;
        if (_levelNext < _maxLevell)
        {
            _cost *= 2;
            _costText.text = _cost.ToString();
            _stars[_levelNext].enabled = true;
        }
        else
        {
            _costText.text = _max.ToString();
            _buyButton.interactable = false;
        }
    }
}
