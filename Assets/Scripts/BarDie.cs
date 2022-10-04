using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarDie : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textDie;

    private int _countDie = 0;

    public void SetCountDie()
    {
        _countDie++;
        _textDie.text = _countDie.ToString();
    }
}
