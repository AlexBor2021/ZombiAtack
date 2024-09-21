using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishWave : MonoBehaviour
{
    [SerializeField] private ModeSwitchUI _modeSwitchUI;
    [SerializeField] private List<ParticleSystem> _effects;
    [SerializeField] private AudioSource _batleSound;
    [SerializeField] private AudioSource _notBatleSound;
    [SerializeField] private AudioSource _win;

    public event UnityAction FinishedWave;
    private void OnEnable()
    {
        FinishingWave();
    }
    private void FinishingWave()
    {
        _win.Play();
        _batleSound.Stop();
        FinishedWave?.Invoke();
        Invoke("OffText", 6);
        SwitchEffect(true);
        _modeSwitchUI.SetUIShop();
    }
    private void OffText()
    {
        SwitchEffect(false);
        _notBatleSound.Play();
        gameObject.SetActive(false);
    }
    private void SwitchEffect(bool enable)
    {
        foreach (var effect in _effects)
        {
            effect.gameObject.SetActive(enable);
        }
    }
}

