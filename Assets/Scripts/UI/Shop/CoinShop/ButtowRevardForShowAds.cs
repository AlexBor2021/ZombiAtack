using UnityEngine;
using TMPro;
using Agava.YandexGames;

public class ButtowRevardForShowAds : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _revardText;
    [SerializeField] private SoundOutSideGame1 _notSound;
    [SerializeField] private Player _player;
    [SerializeField] private int _revard;


    private void Awake()
    {
        _revardText.text = _revard.ToString();
    }

    public void BuyCoin()
    {
        VideoAd.Show(OffGameProces, TakeMoney, OnGameProces);
    }
    private void TakeMoney()
    {
        _player.TakeCoin(_revard);
    }

    private void OffGameProces()
    {
        _notSound.OffSoundInGame(true);
    }
    private void OnGameProces()
    {
        _notSound.OffSoundInGame(false);
    }
}
