using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        transform.position = _player.position;
        transform.rotation = _player.rotation;
    }
}
