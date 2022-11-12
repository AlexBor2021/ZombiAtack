using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGameOver : MonoBehaviour
{
    [SerializeField] private AudioSource _gameOver;
    [SerializeField] private AudioSource _musicBAttle;
    private void OnEnable()
    {
        _musicBAttle.Stop();
        _gameOver.Play();
    }
}
