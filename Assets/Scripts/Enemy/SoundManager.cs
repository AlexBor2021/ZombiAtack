using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _attackSound;
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private AudioSource _punchSound;

    public void PlayDieSound()
    {
        _dieSound.Play();
    }
    public void PlayAttackSound()
    {
        _attackSound.Play();
    }
    public void PlayPunchSound()
    {
        _punchSound.Play();
    }
}
