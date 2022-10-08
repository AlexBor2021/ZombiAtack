using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private Shell _shell;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private Transform _spawShell;
    [SerializeField] private float _dalayForShoting;
    [SerializeField] private ParticleSystem _effectShoot;
    
    private float _rangeBullet = 10f;
    private bool _playerShoot = false;
    private Coroutine _shooting;

    private void OnEnable()
    {
        _effectShoot.Stop();
    }
    public float RangeBullet => _rangeBullet;

    private IEnumerator CreatShell(Enemy enemy)
    {
        while (enemy != null)
        {
            Instantiate(_shell, _spawShell);
            Instantiate(_bullet, _spawnBullet);
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
}
