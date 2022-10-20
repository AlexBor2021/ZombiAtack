using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Destructible _destructible;

    private float _currentHealth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _healthBar.maxValue = (float)_destructible.Health;
        _healthBar.value = (float)_destructible.Health;
    }

    private void Update()
    {
        if (_destructible.Health != _healthBar.value)
        {
            _healthBar.value = _destructible.Health;
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }

}
