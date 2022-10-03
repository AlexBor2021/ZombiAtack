using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _timeLive;
    
    private void Update()
    {
        Destroy(gameObject, _timeLive);
    }
}
