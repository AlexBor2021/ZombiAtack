using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTower : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _cost;
    [SerializeField] private Button _buttonUpgrade;
    [SerializeField] private List<Image> _stars;

    public void TakeInfo(int cost, int level, int maxLevel, Player player = null)
    {
        if (level <= maxLevel)
        {
            _cost.text = cost.ToString();
            _stars[level].enabled = true;
            SetColorCost(cost, player);
            _buttonUpgrade.interactable = true;
        }
    }
    public void SetMaxLevel()
    {
        _buttonUpgrade.interactable = false;
        _cost.text = " ";
    }
    private void SetColorCost(int cost, Player player = null)
    {
        if (player?.Coin < cost)
            _cost.color = Color.red;
        else if(player?.Coin > cost)
            _cost.color = Color.white;
    }

}
