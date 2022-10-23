using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDoor : MonoBehaviour
{
    [SerializeField] private GameObject _board;
    [SerializeField] private GameObject _boardDestractabl;

    public float PersentForDestroy;
    public void Destroy()
    {
        _board.SetActive(false);
        var boardDestractabl = Instantiate(_boardDestractabl, transform.position, transform.rotation);
        Destroy(boardDestractabl, 2f);
    }
    
}
