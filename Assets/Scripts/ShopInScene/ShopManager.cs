using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _shopPanel.SetActive(false);
        }
    }
    private void OnDisable()
    {
        _shopPanel.SetActive(false);
    }
}
