using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRevard : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 800f);
    }
}
