using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _coin = 0;
    private int _almaz = 0;

    public int Coin => _coin;
    public event UnityAction<int> AddedCoin;
    public event UnityAction<int> AddedAlmaz;

    public void TakeCoin(int coin)
    {
        _coin += coin;
        AddedCoin?.Invoke(_coin);
       
    }
    public void TakeAlmaz(int almaz)
    {
        _almaz += almaz;
        AddedAlmaz?.Invoke(_coin);
    }

    public void GiveCoin(int cost)
    {
        _coin -= cost;
        AddedCoin?.Invoke(_coin);
    }
}
