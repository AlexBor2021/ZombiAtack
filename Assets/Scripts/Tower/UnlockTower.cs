using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockTower : MonoBehaviour
{
    [SerializeField] private GameObject _unlockCanvas;
    [SerializeField] private GameObject _casle;
    [SerializeField] private UpgradeTower _upgradeTower;
    [SerializeField] private TextMeshProUGUI _costText; 
    [SerializeField] private ModeSwitchUI _modeSwitchUI;

    private int _costUnLock = 5;
    private Player _player;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _unlockCanvas.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_player?.Coin >= _costUnLock)
            _costText.color = Color.white;
        else
            _costText.color = Color.red;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = null;
            _unlockCanvas.SetActive(false);
        }    
    }
    public void Unlock()
    {
        if (_player?.Coin >= _costUnLock)
        {
            _player.GiveCoin(_costUnLock);
            _unlockCanvas.gameObject.SetActive(false);
            _upgradeTower.gameObject.SetActive(true);
            gameObject.SetActive(false);
            _modeSwitchUI.DeleteInList(gameObject);
        }
    }
}
