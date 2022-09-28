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
    [SerializeField] private Transform _pool;
    
    private Shell _shellPool;
    private Bullet _bulletPool;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shooting());
        }
    }

    private IEnumerator Shooting()
    {
        _shellPool = Instantiate(_shell, _spawShell);
        _shellPool.transform.SetParent(_pool);
        _bulletPool = Instantiate(_bullet, _spawnBullet.position, _spawnBullet.rotation);
        yield return new WaitForSeconds(_dalayForShoting);
    }
}
