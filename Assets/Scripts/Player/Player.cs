using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _player;
    [SerializeField] private Destructible _destructible;
    [SerializeField] private GameObject _panelDie;
    [SerializeField] private BarForAttacks _barForAttacks;

    private SkinInstaller _skinInstaller;
    private int _coin = 0;
    private int _almaz = 0;

    private int _coinInBeginWave = 0;
    private int _almazInBeginWave = 0;

    public int Coin => _coin;
    public event UnityAction<int> AddedCoin;
    public event UnityAction<int> AddedAlmaz;
    private void OnEnable()
    {
        _barForAttacks.StartedAttack += SetCoinAndAlmazInWave;
    }
    private void OnDisable()
    {
        _barForAttacks.StartedAttack -= SetCoinAndAlmazInWave;
    }
    private void Update()
    {
        if (_destructible.Health <= 0)
        {
            Die();
        }
    }
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
    public void ResartCoinAndAlmaz()
    {
        _coin = _coinInBeginWave;
        _almaz = _coinInBeginWave;
    }
    public void SetSkinMaterial(Material material, SkinInstaller skinInstaller)
    {
        if (_skinInstaller != null)
            _skinInstaller.SkinTakeOff();
        _player.materials[0] = material;
        _skinInstaller = skinInstaller;
    }
    private void Die()
    {
        Time.timeScale = 0;
        _panelDie.SetActive(true);
    }
    private void SetCoinAndAlmazInWave()
    {
        _almazInBeginWave = _almaz;
        _coinInBeginWave = _coin;
    }
}
