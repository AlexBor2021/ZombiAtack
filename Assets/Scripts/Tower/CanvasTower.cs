using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private Button _buttonUpgrade;

    public void TakeInfo(int cost, int level)
    {
        _cost.text = cost.ToString();
        _level.text = level.ToString();
    }
    public void SetMaxLevel()
    {
        _buttonUpgrade.interactable = false;
        _level.text = "max";
        _cost.text = " ";
    }
    public void SetColorCost(bool notCoin)
    {
        if (notCoin)
            _cost.color = Color.red;
        else
            _cost.color = Color.white;
    }

}
