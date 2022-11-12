using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IconTower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberLevelTower;
    [SerializeField] private Image _imageLevelTower;
    [SerializeField] private FinishWave _finishWave;
    [SerializeField] private ModeSwitchUI _modeSwitchUI;
    [SerializeField] private UIStay _uIStay;
    [SerializeField] private BoxCollider _boxCollider;

    private bool _isTower = false;

    private void OnEnable()
    {
        _finishWave.FinishedWave += SwitchUIOn;
        _modeSwitchUI.StartedAttack += SwitchUIOff;
    }
    private void OnDisable()
    {
        _modeSwitchUI.StartedAttack -= SwitchUIOff;
        _finishWave.FinishedWave -= SwitchUIOn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _uIStay.SetColorIcon(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _uIStay.SetColorIcon(false);
        }
    }
    public void SetIconTower(int levelTower, int maxLevel)
    {
        _imageLevelTower.gameObject.SetActive(true);
        _numberLevelTower.text = levelTower.ToString();
        if (levelTower == maxLevel)
        {
            _uIStay.SwithUI(false);
            _isTower = false;
        }
        else
        {
            _uIStay.SwithUI(true);
            _isTower = true;
        }
    }
    private void SwitchUIOn()
    {
        if (_isTower)
        {
            _uIStay.SwithUI(true);
        }
        _boxCollider.enabled = true;
    }
    private void SwitchUIOff()
    {
        _uIStay.SwithUI(false);
        _boxCollider.enabled = false;
    }

}
