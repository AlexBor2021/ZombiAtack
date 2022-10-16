using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private VariableJoystick _variableJoystick;
    [SerializeField] private Rigidbody _rigiBody;
    [SerializeField] private Animation _animation;

    private List<Enemy> _enemies;

    public const string Speed = "Speed";


    public void FixedUpdate()
    {
        _rigiBody.velocity = new Vector3(_variableJoystick.Horizontal * _speed, _rigiBody.velocity.y, _variableJoystick.Vertical * _speed);
        
        if (_variableJoystick.Horizontal != 0 || _variableJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigiBody.velocity);
            _animation.SetMove(true);
        }
        else
        {
            _animation.SetMove(false);
        }
    }
}