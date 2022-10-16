using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarAlmaz : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _almazBar;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.AddedAlmaz += RefreshBar;
    }

    private void OnDisable()
    {
        _player.AddedAlmaz -= RefreshBar;
    }

    private void RefreshBar(int almazPlayer)
    {
        _almazBar.text = almazPlayer.ToString();
    }
}
