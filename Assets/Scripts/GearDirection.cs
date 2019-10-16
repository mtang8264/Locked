using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearDirection : MonoBehaviour
{
    public bool counter;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Play()
    {
        if(counter)
        {
            GetComponent<Animator>().Play("Counter");
        }
        else
        {
            GetComponent<Animator>().Play("Clockwise");
        }
    }
}
