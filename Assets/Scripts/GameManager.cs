using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool doorUnlocked;
    public Transform door;
    public Vector3 doorPosition;
    public Vector3 doorRotation;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    public void Update()
    {
        if(doorUnlocked)
        {
            door.position = doorPosition;
            door.localEulerAngles = doorRotation;
        }
    }
}
