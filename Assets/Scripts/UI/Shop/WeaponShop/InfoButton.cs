using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    [SerializeField] private GameObject _infoPanel;

    public void SwitchPanel()
    {
        if (_infoPanel.activeSelf)
        {
            _infoPanel.SetActive(false);
        }
        else
        {
            _infoPanel.SetActive(true);
        }
    }
}
