using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _timeLive;
    
    private float _time;
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeLive)
        {
            Destroy(gameObject);
        }
    }
}
