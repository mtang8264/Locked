using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTimer : MonoBehaviour
{
    private static MusicTimer instance;

    public float time;

    public AudioSource musicSource;

    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(musicSource == null)
        {
            if(GameObject.Find("Music") == null)
            {
                Destroy(this);
            }
            musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
            musicSource.time = time;
        }

        time = musicSource.time;
    }
}
