using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera bedroom;
    public Camera outside;

    public float threshold;

    public Transform player;

    void Start()
    {
        
    }

    void Update()
    {
        if(player.position.x < threshold)
        {
            outside.depth = 0;
            bedroom.depth = 1;
        }
        else
        {
            outside.depth = 1;
            bedroom.depth = 0;
        }
    }
}
