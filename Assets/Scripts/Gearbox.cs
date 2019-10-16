using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearbox : MonoBehaviour
{
    public static bool complete;
    private bool active = false;

    public GearDirection[] gears;

    void Start()
    {
        complete = false;
    }

    void Update()
    {
        if(complete && !active)
        {
            active = true;

            Destroy(GetComponent<Animator>());

            foreach(GearDirection g in gears)
            {
                g.gameObject.SetActive(true);
                g.Play();
            }
        }
    }
}
