using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarAlmaz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _almazBar;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _almazBar.text = _player.Almaz.ToString();
    }
    private void OnEnable()
    {
        _player.ChangedAlmaz += RefreshBar;
    }

    private void OnDisable()
    {
        _player.ChangedAlmaz -= RefreshBar;
    }

    private void RefreshBar(int almazPlayer)
    {
        _almazBar.text = almazPlayer.ToString();
    }
}
