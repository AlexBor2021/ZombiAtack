using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerButtonShop : MonoBehaviour
{
    [SerializeField] private ButtonShop _currentButtonShop;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void SetCurrentButtonShop(ButtonShop buttonShop)
    {
        _currentButtonShop.OffClick();
        _currentButtonShop = buttonShop;
    }
}
