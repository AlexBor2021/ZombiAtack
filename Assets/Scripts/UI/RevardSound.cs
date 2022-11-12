using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevardSound : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 3f);
    }
}
