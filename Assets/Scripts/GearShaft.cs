using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearShaft : MonoBehaviour
{
    public static int complete;

    public int targetSize;
    public GameObject gear;

    void Start()
    {
        complete = 0;
    }

    void Update()
    {
        
    }

    public void Place()
    {
        gear.SetActive(true);

        complete++;

        Destroy(this);
    }
}
