using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;

    private TargetsForEnemy _targetsForEnemy;
    private Door _door;
    private Player _player;
    private Coroutine _giveDamagePlayer;
    private Coroutine _giveDamageDoor;
    private int _damage = 5;
    private float _dalay = 3f;
    private float _distanceAtack = 2f;
    private const string DamageOnDoor = "GiveDamageDoor";

    private void OnEnable()
    {
        _targetsForEnemy = transform.parent.GetComponent<TargetsForEnemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Door>(out Door door))
        {
            _door = door;
            _giveDamageDoor = StartCoroutine(GiveDamageDoor());
        }
        if (other.TryGetComponent<Player>(out Player player))
        {
            Debug.Log(1);
            _player = player;
            _giveDamagePlayer = StartCoroutine(GiveDamagePlayer());
        }
    }

    private IEnumerator GiveDamageDoor()
    {
        yield return new WaitForSeconds(0.5f);
        while (_door.Health > 0)
        {
            _door.TakeDamage(_damage);
            _enemyMove.StopMoveTriger = true;
            yield return new WaitForSeconds(_dalay);
        }
        Debug.Log(_giveDamageDoor);
        StopCoroutine(_giveDamageDoor);
        _enemyMove.StopMoveTriger = false;
        _targetsForEnemy.DestroyTarget();
    }

    private IEnumerator GiveDamagePlayer()
    {
        while (_player.Health > 0 && Vector3.Distance(transform.position, _player.transform.position) < _distanceAtack)
        {
            _player.TakeDamage(_damage);
            _enemyMove.StopMoveTriger = true;
            yield return new WaitForSeconds(_dalay);
        }
        StopCoroutine(_giveDamagePlayer);
        _enemyMove.StopMoveTriger = false;
    }
}
