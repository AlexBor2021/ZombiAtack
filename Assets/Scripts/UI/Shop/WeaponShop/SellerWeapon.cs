using UnityEngine;
using TMPro;

public class SellerWeapon : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _cost;
    [SerializeField] private TextMeshProUGUI _textCost;
    [SerializeField] private GameObject _panel;

    private bool _isBuy = false;

    public bool IsBuy => _isBuy;

    private void Awake()
    {
        _textCost.text = _cost.ToString();
    }
    private void Update()
    {
        if (_player.Coin >= _cost)
        {
            _textCost.color = Color.white;
        }
        else
        {
            _textCost.color = Color.red;
        }
    }
    public void BuyWeapon()
    {
        if (_player.Coin >= _cost)
        {
            _isBuy = true;
            _player.GiveCoin(_cost);
            _panel.SetActive(false);
        }
    }
    public void DataWeaponSeller(bool isBuy)
    {
        if (isBuy)
        {
            _isBuy = true;
            _panel.SetActive(false);
        }
    }
}
