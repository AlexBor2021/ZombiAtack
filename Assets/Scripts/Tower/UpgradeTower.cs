using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UpgradeTower : MonoBehaviour
{
    [SerializeField] private List<Tower> _towers;
    [SerializeField] private TowerSave _towerSave;
    [SerializeField] private GameObject _imageSoldje;
    [SerializeField] private CanvasTower _canvasTower;
    [SerializeField] private IconTower _iconTower;
    
    private Tower _currentTower;
    private int _numberTower = 0;
    private Player _player;

    public int MaxLevelTower => _towers.Count;
    private void OnEnable()
    {
        _canvasTower.TakeInfo(_towers[_numberTower].Cost, _numberTower, MaxLevelTower, _player);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
            _canvasTower.gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (_numberTower < _towers.Count)
        {
            _canvasTower.TakeInfo(_towers[_numberTower].Cost, _numberTower, MaxLevelTower, _player);
        }
        else
        {
            _canvasTower.SetMaxLevel();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = null;
            _canvasTower.gameObject.SetActive(false);
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
        if (_player?.Coin >= _towers[_numberTower].Cost && _numberTower < MaxLevelTower)
        {
            _towerSave.TakeLevelTower(_towers[_numberTower].Level);
            _player.GiveCoin(_towers[_numberTower].Cost);
            var tower = Instantiate(_towers[_numberTower], transform.position, transform.rotation);
            SetCuurentTower(tower);
            _numberTower++;
            _iconTower.SetIconTower(_numberTower, MaxLevelTower);
            _imageSoldje.SetActive(false);
        }
    }
    public void SetDataTower(int level)
    {
        level--;
        var tower = Instantiate(_towers[level], transform.position, Quaternion.identity);
        SetCuurentTower(tower);
        level++;
         _canvasTower.TakeInfo(_towers[level].Cost, _numberTower, MaxLevelTower);
        _iconTower.SetIconTower(level, MaxLevelTower);
    }
}
