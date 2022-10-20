using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private EnemyMove _enemyMove;

    private void Update()
    {
        transform.LookAt(_enemyMove.Target.transform);
    }
}
