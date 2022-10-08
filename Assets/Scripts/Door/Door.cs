using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private List<GameObject> _boardsCrash;
    [SerializeField] private List<GameObject> _boards;

    private int _health = 60;
    private int _cuurentBoard = 0;
    private float _healthForPersent;
    public int Health => _health;

    private void OnEnable()
    {
        _healthForPersent = _health;
    }

    private void Update()
    {
        if (_health <= SetPersent(_healthForPersent, 65))
        {
            DestroyDoor(0);
        }
        if (_health <= SetPersent(_healthForPersent, 35))
        {
            DestroyDoor(1);
        }
        if(_health <= SetPersent(_healthForPersent, 5))
        {
            DestroyDoor(2);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    private float SetPersent(float number, float persentCurent)
    {
        float persent = number / 100 * persentCurent;
        return persent;
    }

    private void DestroyDoor(int numberBoard)
    {
        if (_boards[numberBoard].activeSelf)
        {
            _boards[numberBoard].SetActive(false);
            _boardsCrash[numberBoard].SetActive(true);
            _cuurentBoard++;
        }
    }
}
