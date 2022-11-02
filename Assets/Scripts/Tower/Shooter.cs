using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private Rifle _rifle;

    private float _speedLook = 5;

    private void Awake()
    {
        _rifle.UpgradeBullet(_damage);
    }

    public void LookOnTraget(Enemy enemyTarget)
    {
        Vector3 diraction = (enemyTarget.transform.position - transform.position).normalized;
        Quaternion quaternion = Quaternion.LookRotation(new Vector3(diraction.x, 0, diraction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, _speedLook * Time.deltaTime);
    }
}
