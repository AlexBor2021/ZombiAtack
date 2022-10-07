using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsForEnemy : MonoBehaviour
{
    [SerializeField] private  List<GameObject> _targets;

    private int _currentTargetNumber = 0;
    
    public GameObject CurrentTarget;

    private void OnEnable()
    {
        CurrentTarget = _targets[_currentTargetNumber];
    }

    public void SetTarget()
    {
        CurrentTarget = _targets[_currentTargetNumber];
    }

    public void DestroyTarget()
    {
        
    }
}
