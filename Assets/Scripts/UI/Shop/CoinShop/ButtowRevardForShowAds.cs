using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtowRevardForShowAds : MonoBehaviour
{
    [SerializeField] private YandexGamesSDK _yandexGamesSDK;
    [SerializeField] private TextMeshProUGUI _revardText;
    [SerializeField] private Player _player;
    [SerializeField] private int _revard;


    private void Awake()
    {
        _revardText.text = _revard.ToString();
    }

    public void BuyCoin()
    {
        _yandexGamesSDK.OnShowVideoButtonClick();
        _player.TakeCoin(_revard);
    }
}
