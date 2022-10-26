using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeTower : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private List<Tower> _towers;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private TextMeshProUGUI _costTower;
    [SerializeField] private TowerSave _towerSave;

    private Tower _currentTower;
    private Player _player;
    private int _levelTower = 0;

    public int LevelTower => _levelTower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && _levelTower < _towers.Count)
        {
            _player = player;
            
            _upgradeCanvas.SetActive(true);
            
            if (_player.Coin >= _towers[_levelTower].Cost)
                _costTower.color = Color.white;
            else
                _costTower.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _upgradeCanvas.SetActive(false);
    }
    public void SetCuurentTower(Tower tower)
    {
        if (_currentTower != null)
        {
            Destroy(_currentTower.gameObject);
        }
        _currentTower = tower;
    }
    public void BuyTower()
    {
        if (_player.Coin >= _towers[_levelTower].Cost)
        {
            var tower = Instantiate(_towers[_levelTower], transform.position, Quaternion.identity);
            SetCuurentTower(tower);
            _player.GiveCoin(_towers[_levelTower].Cost);
            _levelTower++;
            _towerSave.TakeLevelTower(_levelTower);
        }
        if(_levelTower >= _towers.Count)
        {
            _upgradeCanvas.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            SetLebelNextTower();
        }
    }
    public void SetDataTower(int level)
    {
        level--;
        var tower = Instantiate(_towers[level], transform.position, Quaternion.identity);
        SetCuurentTower(tower);
        _levelTower++;
        if (level >= _towers.Count)
        {
            _upgradeCanvas.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            SetLebelNextTower();
        }
    }
    private void SetLebelNextTower()
    {
        _numberLevel.text = _towers[_levelTower].Level.ToString();
        _costTower.text = _towers[_levelTower].Cost.ToString();
    }
}
