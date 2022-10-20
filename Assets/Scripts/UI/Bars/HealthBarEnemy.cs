using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Enemy _enemy;

    private float _currentHealth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _healthBar.maxValue = (float)_enemy.Health;
        _healthBar.value = (float)_enemy.Health;
    }

    private void Update()
    {
        if (_enemy.Health != _healthBar.value)
        {
            _healthBar.value = _enemy.Health;
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }

}
