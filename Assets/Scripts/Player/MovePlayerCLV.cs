using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerCLV : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private float _speed = 3;

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            _animation.SetMove(true);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -_speed * Time.deltaTime);
            _animation.SetMove(true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
            _animation.SetMove(true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * -_speed * Time.deltaTime);
            _animation.SetMove(true);
        }
        else
        {
            _animation.SetMove(false);
        }
    }
}
