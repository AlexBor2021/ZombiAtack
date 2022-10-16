using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDoor : MonoBehaviour
{
    [SerializeField] private GameObject _board;
    [SerializeField] private Rigidbody _boardsRb;

    public float PersentForDestroy;

    private const string _offRbBoard = "OffRbBoard";
    private float _forse = 3000f;

    public void Destroy()
    {
        _board.SetActive(false);
        _boardsRb.gameObject.SetActive(true);
        _boardsRb.AddForce(-transform.right * _forse);
        Invoke(_offRbBoard, 3f);
    }

    private void OffRbBoard()
    {
        _boardsRb.gameObject.SetActive(false);
    }
}
