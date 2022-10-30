using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHandle : MonoBehaviour
{
    [SerializeField] private Transform _handle;

    private KeyMove _key;
    private Vector2 Input;
    private void Awake()
    {
        _key = new KeyMove();
        _key.Player.Move.performed += ctx => OnMove();
    }
    private void OnEnable()
    {
        _key.Enable();
    }
    private void OnDisable()
    {
        _key.Disable();
    }
    private void Update()
    {
        transform.Translate(Input.x, 0, Input.y);
    }
    public void OnMove()
    {
        Input = _key.Player.Move.ReadValue<Vector2>();
        Debug.Log(Input);
    }
}
