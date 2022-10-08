using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Player _player;

    private float _currentHealth;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _healthBar.maxValue = (float)_player.Health;
        _healthBar.value = (float)_player.Health;
    }

    private void Update()
    {
        if (_player.Health != _healthBar.value)
        {
            Debug.Log(1);
            _healthBar.value = _player.Health;
        }
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }

}
