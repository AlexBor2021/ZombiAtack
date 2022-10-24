using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDoor : MonoBehaviour
{
    [SerializeField] private GameObject _board;
    [SerializeField] private GameObject _boardDestractablPrefab;

    public float PersentForDestroy;
    public void Destroy()
    {
        _board.SetActive(false);
        var BoardDestractabl = Instantiate(_boardDestractablPrefab, transform);
        Destroy(BoardDestractabl, 2f);
    }
}
