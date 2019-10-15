using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{
    public PlayerControls player;

    public AudioSource instantSound;
    public AudioSource oldMusic;
    public AudioSource[] newMusic;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        instantSound.Play();
        oldMusic.Stop();
        foreach(AudioSource a in newMusic)
        {
            a.Play();
            a.timeSamples = 0;
        }

        player.speed = 8;

        RenderSettings.fogColor = new Color(0.3107868f, 0.6792453f, 0.3559979f);

        transform.GetChild(0).gameObject.SetActive(true);

        Destroy(this);
    }
}
