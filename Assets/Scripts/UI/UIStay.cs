using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Image _icon;

    public void SetColorIcon(bool stay)
    {
        if (stay)
        {
            _text.color = Color.green;
            _icon.color = Color.green;
        }
        else
        {
            _text.color = Color.white;
            _icon.color = Color.white;
        }
    }
    public void SwithUI(bool work)
    {
        _text.gameObject.SetActive(work);
    }
}
