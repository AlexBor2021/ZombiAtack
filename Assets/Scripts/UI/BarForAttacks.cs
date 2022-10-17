using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarForAttacks : MonoBehaviour
{
    [SerializeField] private BarDie _barDie;
    [SerializeField] private WaveBar _waveBar;
    [SerializeField] private Button _shop;
    [SerializeField] private Button _nextWave;
    [SerializeField] private GameObject _upgradeShopText;

    public void SetUIAttack()
    {
        _barDie.gameObject.SetActive(true);
        _upgradeShopText.gameObject.SetActive(false);
        _waveBar.gameObject.SetActive(true);
        _shop.gameObject.SetActive(false);
        _nextWave.gameObject.SetActive(false);
    }
    public void SetUIShop()
    {
        _barDie.gameObject.SetActive(false);
        _waveBar.gameObject.SetActive(false);
        _shop.gameObject.SetActive(true);
        _nextWave.gameObject.SetActive(true);
        _upgradeShopText.gameObject.SetActive(true);
    }
}
