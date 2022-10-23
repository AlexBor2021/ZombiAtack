using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Destructible _destructible;
    [SerializeField] private GameObject _panelDie;
    [SerializeField] private ModeSwitchUI _barForAttacks;
    [SerializeField] private SkinInstaller _skinInstallerDefoult;

    private SkinInstaller _skinInstaller;
    private int _coin = 5000;
    private int _almaz = 0;
    private int _coinInBeginWave = 0;
    private int _almazInBeginWave = 0;

    public int Coin => _coin;
    public int Almaz => _almaz;
    public event UnityAction<int> ChangedCoin;
    public event UnityAction<int> ChangedAlmaz;
    private void OnEnable()
    {
        _skinInstaller = _skinInstallerDefoult;
        _barForAttacks.StartedAttack += SetCoinAndAlmazInWave;
    }
    private void OnDisable()
    {
        _barForAttacks.StartedAttack -= SetCoinAndAlmazInWave;
    }
    private void Update()
    {
        if (_destructible.Health <= 0)
            Die();
    }
    public void TakeCoin(int coin)
    {
        _coin += coin;
        ChangedCoin?.Invoke(_coin);
    }
    public void TakeAlmaz(int almaz)
    {
        _almaz += almaz;
        ChangedAlmaz?.Invoke(_almaz);
    }
    public void GiveCoin(int cost)
    {
        _coin -= cost;
        ChangedCoin?.Invoke(_coin);
    }
    public void GiveAlmaz(int almaz)
    {
        _almaz -= almaz;
        ChangedAlmaz?.Invoke(_coin);
    }
    public void ResartCoinAndAlmaz()
    {
        _coin = _coinInBeginWave;
        _almaz = _almazInBeginWave;
        transform.position = new Vector3(0, 0, 0);
        ChangedCoin?.Invoke(_coin);
        ChangedAlmaz?.Invoke(_almaz);
    }
    public void SetSkinMaterial(Material material, SkinInstaller skinInstaller)
    {
        _skinInstaller.SkinTakeOff();
        _skinnedMeshRenderer.material = material;
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
