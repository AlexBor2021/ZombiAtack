using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnlockTower : MonoBehaviour
{
    [SerializeField] private GameObject _unlockCanvas;
    [SerializeField] private GameObject _castleImage;
    [SerializeField] private UpgradeTower _upgradeManager;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private BoxCollider _boxCollider;

    private int _costUnLock = 10;
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
        if (_player.Coin >= _costUnLock)
        {
            _player.GiveCoin(_costUnLock);
            Destroy(_castleImage);
            Destroy(_unlockCanvas);
            _upgradeManager.gameObject.SetActive(true);
            _boxCollider.enabled = false;
        }
    }
}
