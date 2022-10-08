using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarDie : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDie;

    private int _countDie = 0;

    private void OnEnable()
    {
        _textDie.text = _countDie.ToString();
    }

    public void SetCountDie(Enemy enemy)
    {
        enemy.DiedEnemy -= SetCountDie;
        _countDie++;
        _textDie.text = _countDie.ToString();
    }
}
