using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsForEnemy : MonoBehaviour
{
    [SerializeField] private  GameObject _target;
    public GameObject Target => _target;

    public void SetTargetRevard(GameObject target)
    {
        target = _target;
    }
}
