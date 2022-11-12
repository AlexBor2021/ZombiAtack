using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonShop : MonoBehaviour
{
    [SerializeField] private Image _focus;
    [SerializeField] private GameObject _panel;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private ManagerButtonShop _managerButtonShop;
    [SerializeField] private Color _color;

    public void OnClick()
    {
        _focus.enabled = true;
        //_text.color = Color.white;
        _panel.SetActive(true);
        _managerButtonShop.SetCurrentButtonShop(this);
    }

    public void OffClick()
    {
        _panel.SetActive(false);
        _focus.enabled = false;
        //_text.color = _color; 
    }

    
}
