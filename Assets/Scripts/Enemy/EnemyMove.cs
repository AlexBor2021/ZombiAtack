using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private List<GameObject> _targets;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    
    private int _countTraget = 0;

    public const string Atack = "Atack";

    private void Update()
    {
        if (Vector3.Distance(transform.position, _targets[_countTraget].transform.position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targets[_countTraget].transform.position, _speed * Time.deltaTime);
        }
        else
        {
            _animator.SetBool(Atack, true);
        }
        transform.rotation = Quaternion.LookRotation(-_targets[_countTraget].transform.position);
    }

    public void GetTarget(GameObject _target)
    {
        _targets.Add(_target);
    }
}
