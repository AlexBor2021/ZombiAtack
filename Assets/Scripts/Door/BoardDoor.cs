using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDoor : MonoBehaviour
{
    [SerializeField] private Rigidbody _boardsRb;

    private const string _offRbBoard = "OffRbBoard";
    private float _forse = 3000f;

    private void OnEnable()
    {
        _boardsRb.AddForce(transform.up * _forse);
        Invoke(_offRbBoard, 3f);
    }

    private void OffRbBoard()
    {
        gameObject.SetActive(false);
    }
}
