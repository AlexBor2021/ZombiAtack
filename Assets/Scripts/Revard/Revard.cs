using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revard : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private Collider _findPlaer;
    [SerializeField] private ParticleSystem _effect;

    private Player _player;
    private float _distanceDestroy = 0.1f;
    private float _speed = 10f;

    private void OnEnable()
    {
        transform.parent = null;
        Invoke("OnColiderFinderPlayer", 1.5f);
    }
    
    private void Update()
    {
        if (_player != null)
        {
            _collider.enabled = false;
            _rigidbody.useGravity = false;
            _findPlaer.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _player.transform.position) < _distanceDestroy)
            {
                TakeRevard();
            }
        }
        transform.Rotate(0f, 1f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _player = player;
        }
    }
    private void OnColiderFinderPlayer()
    {
        _findPlaer.enabled = true;
    }
    
    private void TakeRevard()
    {
        if (TryGetComponent<Coin>(out Coin coin))
        {
            _player.TakeCoin(coin.Value);
        }
        if (TryGetComponent<Almaz>(out Almaz almaz))
        {
            _player.TakeAlmaz(almaz.Value);
        }
        Instantiate(_effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
