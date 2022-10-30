using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private Shell _shell;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _bulletPat;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private Transform _spawShell;
    [SerializeField] private ParticleSystem _effectShoot;
    
    private float _dalayForShoting = 0.4f;
    private float _rangeBullet = 10f;
    private bool _playerShoot = false;
    private Coroutine _shooting;
    public float RangeBullet => _rangeBullet;

    private void OnEnable()
    {
        _effectShoot.Stop();
    }
    private IEnumerator CreatShell(Enemy enemy)
    {
        while (enemy != null)
        {
            Instantiate(_shell, _spawShell);
            Instantiate(_bullet, _spawnBullet.position, _spawnBullet.rotation);
            _effectShoot.Play();
            yield return new WaitForSeconds(_dalayForShoting);
        }
        StopCoroutine(_shooting);
        _playerShoot = false;
    }
    public void ShootInEnemy(Enemy enemy)
    {
        if (_playerShoot == false)
        {
            _shooting = StartCoroutine(CreatShell(enemy));
            _playerShoot = true;
        }
    }
    public void StopShoot()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);
            _playerShoot = false;
        }
    }
    public void UpgradeBullet(int Updamage)
    {
        _bullet.Updamage(Updamage);
    }
    public void UpgradeRate(float rate)
    {
        _dalayForShoting -= rate;
    }
}
