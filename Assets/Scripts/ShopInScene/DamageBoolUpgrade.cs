using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DamageBoolUpgrade : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private Player _player;
    [SerializeField] private Button _buyButton;

    private int _cost = 50;
    private int _cuurentBullet = 0;
    private int _levelNext = 2;
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
    public void UpgradeBullet()
    {
        if (_player.Coin >= _cost)
        {
            _costText.color = Color.white;
            _player.GiveCoin(_cost);
            _rifle.UpgradeBullet(_bullets[_cuurentBullet]);
            _cuurentBullet++;
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
