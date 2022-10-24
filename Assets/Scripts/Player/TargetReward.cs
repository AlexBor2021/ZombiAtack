using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReward : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ParticleSystem _effectCoin;
    [SerializeField] private ParticleSystem _effectAlmaz;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Coin>(out Coin coin))
        {
            _player.TakeCoin(coin.TakeCoin());
            Instantiate(_effectCoin, transform);
        }
        if (other.TryGetComponent<Almaz>(out Almaz almaz))
        {
            _effectCoin.Play();
            Instantiate(_effectAlmaz, transform);
        }
    }
}
