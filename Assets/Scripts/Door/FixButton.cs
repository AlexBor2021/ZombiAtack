using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixButton : MonoBehaviour
{
    [SerializeField] private ModeSwitchUI _modeSwitchUI;

    private Camera _camera;
    private void OnEnable()
    {
        _modeSwitchUI.StartedAttack += OffGameObject;
    }
    private void OnDisable()
    {
        _modeSwitchUI.StartedAttack -= OffGameObject;
    }
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
    }
    private void OffGameObject()
    {
        gameObject.SetActive(false);
    }
}
