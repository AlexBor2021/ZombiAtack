using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private Shell _shell;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private Transform _spawShell;
    [SerializeField] private float _dalayForShoting;
    
    private Shell _shellPool;
    private GameObject _bulletPool;
    private float _forseForShell = 250f;
    private float _forseForBullet = 2000f;
    private bool _work = false;
    
    private Coroutine _shooting;
    
    private IEnumerator Shooting(Enemy enemy)
    {
        while (enemy != null && Vector3.Distance(enemy.transform.position, transform.position) < 10f)
        {
            _shellPool = Instantiate(_shell, _spawShell);
            _shellPool.transform.parent = null;
            _shellPool.GetComponent<Rigidbody>().AddForce(_spawShell.up * _forseForShell);
            _bulletPool = Instantiate(_bullet, _spawnBullet.position, Quaternion.identity);
            _bulletPool.GetComponent<Rigidbody>().AddForce(_spawnBullet.forward * _forseForBullet);
            yield return new WaitForSeconds(_dalayForShoting);
        }
        StopCoroutine(_shooting);
        _work = false;
    }

    public void ShootInEnemy(Enemy enemy)
    {
        if (_work == false)
        {
            _shooting = StartCoroutine(Shooting(enemy));
            _work = true;
        }
    }
}
