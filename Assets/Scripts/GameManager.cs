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

    [Header("gearbox")]
    public bool gearsDone;
    private bool gearsRead = false;

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

        if(gearsDone && !gearsRead)
        {
            gearsRead = true;
            Gearbox.complete = true;
        }
    }
}
