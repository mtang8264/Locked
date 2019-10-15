using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClose : MonoBehaviour
{
    public Transform player;
    public Transform[] sources;
    public float[] distances;

    void Start()
    {
        
    }

    void Update()
    {
        FindDistances();

        PlayNearest();
    }

    void FindDistances()
    {
        distances = new float[sources.Length];
        for(int i = 0; i < sources.Length; i ++)
        {
            distances[i] = Mathf.Abs( Vector3.Distance(player.position, sources[i].position));
        }
    }

    void PlayNearest()
    {
        int lowest = 0;

        for(int i = 1; i < distances.Length; i++)
        {
            if (distances[lowest] > distances[i])
                lowest = i;
        }

        for (int i = 0; i < sources.Length; i++)
        {
            if(lowest == i)
            {
                sources[i].GetComponent<AudioController>().target = 0.7f;
            }
            else
            {
                sources[i].GetComponent<AudioController>().target = 0;
            }
        }
    }
}
