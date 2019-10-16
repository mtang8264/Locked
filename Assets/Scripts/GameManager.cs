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
    public int gearInHand;
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

        if(GearShaft.complete == 4)
        {
            gearsDone = true;
        }

        if(gearsDone && !gearsRead)
        {
            gearsRead = true;
            Gearbox.complete = true;
        }
    }

    public static void PickUpGear(int i)
    {
        instance.gearInHand = i;
    }
    public static void PlaceGear(GearShaft shaft)
    {
        if(instance.gearInHand == shaft.targetSize)
        {
            shaft.Place();
        }
        instance.gearInHand = 0;
    }
}
