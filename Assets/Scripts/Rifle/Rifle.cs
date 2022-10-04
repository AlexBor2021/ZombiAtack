using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    [SerializeField] private Shell _shell;
    [SerializeField] private Transform _spawnBullet;
    [SerializeField] private Transform _spawShell;
    [SerializeField] private float _dalayForShoting;
    [SerializeField] private ParticleSystem _effectShoot;
    
    private Shell _shellPool;
    private float _forseForShell = 250f;
    private float _rangeBullet = 10f;
    private bool _work = false;
    private int _damage = 3;
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
            _shellPool = Instantiate(_shell, _spawShell);
            _shellPool.transform.parent = null;
            _shellPool.GetComponent<Rigidbody>().AddForce(_spawShell.up * _forseForShell);
            Shooting();
            _effectShoot.Play();
            yield return new WaitForSeconds(_dalayForShoting);
        }
        _effectShoot.Stop();
        StopCoroutine(_shooting);
        _work = false;
    }

    private void Shooting()
    {
        RaycastHit hit;
        if(Physics.Raycast(_spawnBullet.position, _spawnBullet.forward, out hit, _rangeBullet))
        {
            if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy) && enemy.Health > -_damage)
            {
                Debug.Log(enemy.Health);
                enemy.TakeDamage(_damage);
            }
        }
    }

    public void ShootInEnemy(Enemy enemy)
    {
        if (_work == false)
        {
            _shooting = StartCoroutine(CreatShell(enemy));
            _work = true;
        }
    }

    public void StopShoot()
    {
        if (_shooting != null)
        {
            StopCoroutine(_shooting);
            _effectShoot.Stop();
            _work = false;
        }
    }
}
