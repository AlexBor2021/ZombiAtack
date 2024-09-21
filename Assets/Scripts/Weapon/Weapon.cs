using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Shell _shell;
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected Transform _spawnBullet;
    [SerializeField] protected Transform _spawShell;
    [SerializeField] protected ParticleSystem _effectShoot;
    [SerializeField] protected AudioSource _shootsound;
    [SerializeField] protected float _dalayForShoting;

    protected float _rangeBullet = 10f;
    protected bool _shootingStart = false;
    protected Coroutine _shooting;

    public float RangeBullet => _rangeBullet;

    private void OnEnable()
    {
        _effectShoot.Stop();
    }
    private IEnumerator CreatShell(Enemy enemy)
    {
        while (enemy != null)
        {
            Instantiate(_shell, _spawShell.transform);
            var bullet = Instantiate(_bullet, _spawnBullet.position, _spawnBullet.rotation);
            _shootsound.Play();
            _effectShoot.Play();
            yield return new WaitForSeconds(_dalayForShoting);
        }
        StopCoroutine(_shooting);
        _shootingStart = false;
    }
    public void ShootInEnemy(Enemy enemy)
    {
        if (_shootingStart == false)
        {
            _shooting = StartCoroutine(CreatShell(enemy));
            _shootingStart = true;
        }
    }
    public void StopShoot()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);
            _shootingStart = false;
        }
    }
}
