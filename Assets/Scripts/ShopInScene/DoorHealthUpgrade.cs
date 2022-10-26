using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DoorHealthUpgrade : MonoBehaviour
{
    [SerializeField] private List<Destructible> _destructibleDoors;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private Player _player;
    [SerializeField] private Button _buyButton;

    private int _cost = 50;
    private int _health = 100;
    private int _levelNext = 2;
    private int _maxLevell = 5;
    private const string _max = "max";

    public int Currentlevel = 1;

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
    public void UpgradeDoor()
    {
        if (_player.Coin >= _cost)
        {
            _costText.color = Color.white;
            _player.GiveCoin(_cost);
            foreach (var door in _destructibleDoors)
            {
                door.UpgradeHealth(_health);
            }
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
    private void SetCurrentLevel(int level)
    {
        for (int i = 1; i < level; i++)
        {
            SetUI();
            foreach (var door in _destructibleDoors)
            {
                door.UpgradeHealth(_health);
            }
        }
    }
}
