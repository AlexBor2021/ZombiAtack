using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;

    private int _damage = 4;
    private float _dalay = 3f;
    private Door _door;

    private const string DamageOnDoor = "GiveDamageDoor";


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Door>(out _door))
        {
            StartCoroutine(GiveDamageDoor());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Door>(out _door))
        {
            _door = null;
        }
    }

    private IEnumerator GiveDamageDoor()
    {
        while (_door != null)
        {
            _door.TakeDamage(_damage);
            yield return new WaitForSeconds(_dalay);
        }
        StopCoroutine(GiveDamageDoor());
    }
}
