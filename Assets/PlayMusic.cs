using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    private AudioSource MusicSource;

    void Awake()
    {
        MusicSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            if (!MusicSource.isPlaying)
                MusicSource.Play();
        }
    }
}
