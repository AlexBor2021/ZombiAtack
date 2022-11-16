using UnityEngine;

public class SoundEnemy : MonoBehaviour
{
    [SerializeField] private AudioSource _voiceAttack;
    [SerializeField] private AudioSource _punch;
    [SerializeField] private AudioSource _voiceDie;

    public void PlayVoiceAttackSound()
    {
        _voiceAttack.Play();
    }
    public void PlayPunchSound()
    {
        _punch.Play();
    }
    public void PlayVoiceDieSound()
    {
        _voiceDie.Play();
    }
}
