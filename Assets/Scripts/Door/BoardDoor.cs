using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDoor : MonoBehaviour
{
    [SerializeField] private GameObject _board;
    [SerializeField] private GameObject _boardDestractabl;

    private const string _offBoardDestractabl = "OffBoardDestractabl";

    public float PersentForDestroy;
    public void Destroy()
    {
        _board.SetActive(false);
        _boardDestractabl.SetActive(true);
        Invoke(_offBoardDestractabl, 2f);
    }

    public void OffBoardDestractabl()
    {
        _boardDestractabl.SetActive(false);
    }


}
