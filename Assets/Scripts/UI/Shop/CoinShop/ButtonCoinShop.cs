using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonCoinShop : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _revardText;
    [SerializeField] private Player _player;
    [SerializeField] private int _cost;
    [SerializeField] private int _revard;
    

    private void Awake()
    {
        _costText.text = _cost.ToString();
        _revardText.text = _revard.ToString();
    }
    private void Update()
    {
        if (_player.Almaz < _cost)
        {
            _costText.color = Color.red;
        }
        else
        {
            _costText.color = Color.white;
        }
    }

    public void BuyCoin()
    {
        if (_player.Almaz >= _cost)
        {
            _player.GiveAlmaz(_cost);
            _player.TakeCoin(_revard);
        }
    }
}
