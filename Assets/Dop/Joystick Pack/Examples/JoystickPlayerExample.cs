using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    //public void FixedUpdate()
    //{
    //    rb.velocity = new Vector3(variableJoystick.Horizontal * speed, rb.velocity.y, variableJoystick.Vertical * speed);
    //}
}