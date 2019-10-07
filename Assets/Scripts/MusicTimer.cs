using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicTimer : MonoBehaviour
{
    public float time;

    public AudioSource musicSource;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(musicSource == null)
        {
            musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
            musicSource.time = time;
        }

        time = musicSource.time;
    }
}
