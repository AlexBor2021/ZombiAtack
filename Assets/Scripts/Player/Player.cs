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

    private BasaData _basaData;

    private SkinInstaller _skinInstaller;
    private int _coin = 0;
    private int _almaz = 0;
    public int Coin => _coin;
    public int Almaz => _almaz;
    public event UnityAction<int> ChangedCoin;
    public event UnityAction<int> ChangedAlmaz;

    private void OnEnable()
    {
        _skinInstaller = _skinInstallerDefoult;
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
        ChangedAlmaz?.Invoke(_almaz);
    }
    public void Restart()
    {
        transform.position = new Vector3(0, 0, 0);
        _destructible.RecoveryHealth();
    }
    public void SetSkinMaterial(Material material, SkinInstaller skinInstaller)
    {
        _skinInstaller.SkinTakeOff();
        _skinnedMeshRenderer.material = material;
        _skinInstaller = skinInstaller;
    }

    public void Initialise(int coin, int almaz)
    {
        _coin = coin;
        _almaz = almaz;
        ChangedCoin?.Invoke(_coin);
        ChangedAlmaz?.Invoke(_almaz);
    }
    private void Die()
    {
        Time.timeScale = 0;
        _panelDie.SetActive(true);
    }
}
