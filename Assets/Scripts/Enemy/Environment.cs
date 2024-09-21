using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private EnemyAtack _enemyAtack;

    private Destructible _destructible;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _enemyAtack.SetDestructible(destructible);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Destructible>(out Destructible destructible))
        {
            _enemyAtack.ExitDestructible(destructible);
        }
    }
}
