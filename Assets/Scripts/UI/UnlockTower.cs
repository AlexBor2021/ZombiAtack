using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTower : MonoBehaviour
{
    [SerializeField] private GameObject _panelUnlock;
    [SerializeField] private Tower _towerLvlOne;
    [SerializeField] private GameObject _upgrade;
    [SerializeField] private Transform _spawnTower;
    [SerializeField] private UpgradeManager _upgradeManager;

    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _panelUnlock.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = null;
            _panelUnlock.SetActive(false);
        }    
    }

    public void Unlock()
    {
        if (_player.Coin >= _towerLvlOne.Cost)
        {
            _player.GiveCoin(_towerLvlOne.Cost);
            var tower = Instantiate(_towerLvlOne, _spawnTower.position, Quaternion.identity);
            _upgradeManager.SetCuurentTower(tower);
            _panelUnlock.SetActive(false);
            _upgrade.SetActive(true);
            Invoke("Enable", 0.2f);
        }
    }

    private void Enable()
    {
        gameObject.SetActive(false);
    }
}
