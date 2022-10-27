using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTower : MonoBehaviour
{
    [SerializeField] private List<Tower> _towers;
    [SerializeField] private CanvasTower _canvasTower;
    [SerializeField] private TowerSave _towerSave;
    [SerializeField] private UnlockTower _unlockTower;
    [SerializeField] private FinishWave _finishWave;
    [SerializeField] private ModeSwitchUI _modeSwitchUI;

    private Tower _currentTower;
    private Player _player;
    private int _numberTower = 0;

    public int MaxLevelTower => _towers.Count;
    private void OnEnable()
    {
        _finishWave.FinishedWave += SwitchUIOn;
        _modeSwitchUI.StartedAttack += SwitchUIOff;
        _canvasTower.TakeInfo(_towers[_numberTower].Cost, _towers[_numberTower].Level);
    }
    private void OnDisable()
    {
        _modeSwitchUI.StartedAttack -= SwitchUIOff;
        _finishWave.FinishedWave -= SwitchUIOn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && _numberTower < _towers.Count)
        {
            _player = player;
            _canvasTower.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_player?.Coin >= _towers[_numberTower].Cost && _numberTower < MaxLevelTower)
            _canvasTower.SetColorCost(false);
        else
            _canvasTower.SetColorCost(true);
        _currentTower?.SetColorUI(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _canvasTower.gameObject.SetActive(false);
            _currentTower?.SetColorUI(false);
        }
    }
    public void SetCuurentTower(Tower tower)
    {
        if (_currentTower != null)
            Destroy(_currentTower.gameObject);
        
        _currentTower = tower;
    }
    public void BuyTower()
    {
        if (_player.Coin >= _towers[_numberTower].Cost && _numberTower < MaxLevelTower)
        {
            _unlockTower.gameObject.SetActive(false);
            _towerSave.TakeLevelTower(_towers[_numberTower].Level);
            _player.GiveCoin(_towers[_numberTower].Cost);
            var tower = Instantiate(_towers[_numberTower], transform.position, Quaternion.identity);
            SetCuurentTower(tower);
            _numberTower++;
            if (_numberTower < MaxLevelTower)
                _canvasTower.TakeInfo(_towers[_numberTower].Cost, _towers[_numberTower].Level);
            
            else
                _canvasTower.SetMaxLevel();
        }
        
    }
    public void SetDataTower(int level)
    {
        _unlockTower.gameObject.SetActive(false);
        level--;
        var tower = Instantiate(_towers[level], transform.position, Quaternion.identity);
        SetCuurentTower(tower);
        _numberTower++;
         _canvasTower.TakeInfo(_towers[_numberTower].Cost, _towers[_numberTower].Level);
    }
    private void SwitchUIOn()
    {
        _currentTower?.SwichUI(true);
    }
    private void SwitchUIOff()
    {
        _currentTower?.SwichUI(false);
    }
}
