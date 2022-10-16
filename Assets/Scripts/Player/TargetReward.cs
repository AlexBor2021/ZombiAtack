using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReward : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<Coin>(out Coin coin))
        //{
        //    _player.TakeCoin(coin.TakeCoin());
        //}
        //if (other.TryGetComponent<Almaz>(out Almaz almaz))
        //{
        //    _player.TakeAlmaz(almaz.TakeAlmaz());
        //}
    }
}
