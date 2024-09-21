using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDoorRestart : MonoBehaviour
{
    [SerializeField] private List<Door> _doorsRestart;

    public void RestartDoor()
    {
        foreach (var door in _doorsRestart)
        {
            door.RecoveryDoor();
        }
    }
}
