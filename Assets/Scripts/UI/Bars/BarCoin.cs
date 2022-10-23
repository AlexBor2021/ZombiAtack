using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinBar;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _coinBar.text = _player.Coin.ToString();
    }
    private void OnEnable()
    {
        _player.ChangedCoin += RefreshBar;
    }

    private void OnDisable()
    {
        _player.ChangedCoin -= RefreshBar;
    }

    private void RefreshBar(int coinPlayer)
    {
        _coinBar.text = coinPlayer.ToString();
    }
}
