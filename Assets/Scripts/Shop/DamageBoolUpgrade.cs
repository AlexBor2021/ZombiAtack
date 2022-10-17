using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageBoolUpgrade : MonoBehaviour
{
    [SerializeField] private Rifle _rifle;
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private Player _player;

    private int _cost = 50;
    private int _cuurentBullet = 0;
    private int _levelNext = 2;

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
        else
        {
            _costText.color = Color.red;
        }
    }
    private void SetUI()
    {
        _cost *= 2;
        _levelNext++;
        _costText.text = _cost.ToString();
        _numberLevel.text = _levelNext.ToString();
    }
}
