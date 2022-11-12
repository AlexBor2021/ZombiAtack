using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private Destructible _playerHealth;

    private Coroutine _damageEeth;
    private int _damage = 1;
    private float _dalay = 0.1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if(_damageEeth != null)
                StopCoroutine(_damageEeth);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _damageEeth = StartCoroutine(SetGamage());
        }
    }
    private IEnumerator SetGamage()
    {
        while (_playerHealth.Health > 0)
        {
            _playerHealth.TakeDamage(_damage);
            yield return new WaitForSeconds(_dalay);
        }
    }
}
