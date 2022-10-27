using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModeSwitchUI : MonoBehaviour
{
    [SerializeField] private BarDie _barDie;
    [SerializeField] private WaveBar _waveBar;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _nextWave;
    [SerializeField] private GameObject _shopManager;
    [SerializeField] private UnlockTower _unlockTower;

    public event UnityAction StartedAttack;

    public void SetUIAttack()
    {
        _unlockTower?.gameObject.SetActive(false);
        _barDie.gameObject.SetActive(true);
        _waveBar.gameObject.SetActive(true);
        _shopManager.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(false);
        _nextWave.gameObject.SetActive(false);
        StartedAttack?.Invoke();
    }
    public void SetUIShop()
    {
        _unlockTower?.gameObject.SetActive(true);
        _barDie.gameObject.SetActive(false);
        _waveBar.gameObject.SetActive(false);
        _shopButton.gameObject.SetActive(true);
        _nextWave.gameObject.SetActive(true);
        _shopManager.gameObject.SetActive(true);
    }
}
