using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarAlmaz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _almazBar;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _revardSound;

    private void OnEnable()
    {
        _almazBar.text = _player.Almaz.ToString();
        _player.ChangedAlmaz += RefreshBar;
    }

    private void OnDisable()
    {
        _player.ChangedAlmaz -= RefreshBar;
    }

    private void RefreshBar(int almazPlayer)
    {
        _almazBar.text = almazPlayer.ToString();
        Instantiate(_revardSound);
    }
}
