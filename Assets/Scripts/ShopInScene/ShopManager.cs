using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private UIStay _uiStay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _shopPanel.SetActive(true);
            _uiStay.SetColorIcon(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _shopPanel.SetActive(false);
            _uiStay.SetColorIcon(false);
        }
    }
    private void OnDisable()
    {
        if (_shopPanel != null)
            _shopPanel.SetActive(false);
    }
}
