using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private EnemyAnimation _enemyAnimation;

    private int _damage = 4;
    private float _dalay = 3f;
    private Door _door;
    private const string DamageOnDoor = "GiveDamageDoor";

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Door>(out Door door))
        {
            _door = door;
            StartCoroutine(GiveDamageDoor());
        }
    }

    private IEnumerator GiveDamageDoor()
    {
        while (_door.Health > 0)
        {
            _door.TakeDamage(_damage);
            yield return new WaitForSeconds(_dalay);
        }
        StopCoroutine(GiveDamageDoor());
        _enemyAnimation.SetAtack(false);
    }
}
