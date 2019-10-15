using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public float current;
    public float target;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        current = Mathf.Lerp(current, target, Time.deltaTime);

        source.volume = current;
    }
}
