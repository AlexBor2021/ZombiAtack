using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;
    [SerializeField] private EnemyAnimation _enemyAnimation;

    private Destructible _destructible;
    private Coroutine _giveDamage;
    private int _damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _destructible = destructible;
            Attack(true);
            _giveDamage = StartCoroutine(GiveDamage());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _destructible = null;
            Attack(false);
            if (_giveDamage != null)
                StopCoroutine(_giveDamage);
        }
    }
    private IEnumerator GiveDamage()
    {
        while (_destructible.Health > 0)
        {
            yield return new WaitForSeconds(2f);
            _destructible.TakeDamage(_damage);
        }
        Attack(false);
        StopCoroutine(_giveDamage);
    }
    private void Attack(bool work)
    {
        _enemyMove.StopMoveTriger = work;
        _enemyAnimation.SetAtackAndMove(work);
    }
}
