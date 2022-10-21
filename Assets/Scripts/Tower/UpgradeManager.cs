using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private GameObject _upgradeCanvas;
    [SerializeField] private List<Tower> _towers;
    [SerializeField] private TextMeshProUGUI _numberLevel;
    [SerializeField] private TextMeshProUGUI _costTower;

    private Tower _currentTower;
    private Player _player;
    private int _numberTower = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player) && _numberTower < _towers.Count)
        {
            _player = player;
            _upgradeCanvas.SetActive(true);
            if (_player.Coin >= _towers[_numberTower].Cost)
            {
                _costTower.color = Color.white;
            }
            else
            {
                _costTower.color = Color.red;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _upgradeCanvas.SetActive(false);
        }
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
        if (_player.Coin >= _towers[_numberTower].Cost)
        {
            var tower = Instantiate(_towers[_numberTower], transform.position, Quaternion.identity);
            SetCuurentTower(tower);
            _player.GiveCoin(_towers[_numberTower].Cost);
            _numberTower++;
        }
        if(_numberTower >= _towers.Count)
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
        _numberLevel.text = _towers[_numberTower].Level.ToString();
        _costTower.text = _towers[_numberTower].Cost.ToString();
    }
}
