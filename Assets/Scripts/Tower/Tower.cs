using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tower : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private int _level;

    public int Cost => _cost;
    public int Level => _level;

    private void Start()
    {
        transform.DOScale(new Vector3(1, 1, 1), 0.5f);
    }

}
