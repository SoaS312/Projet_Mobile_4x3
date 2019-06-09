using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public bool vibrations = true;
    public bool sound = true;
    public bool music = true;

    public GameObject MusicBarre;
    public GameObject SoundBarre;
    public GameObject VibrationBarre;

    public void Update()
    {
        if (!PlayerPrefs.HasKey("Vibrations")){
            VibrationBarre.SetActive(false);
        }
        else
        {
            VibrationBarre.SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Sound"))
        {
            SoundBarre.SetActive(false);
        }
        else
        {
            SoundBarre.SetActive(true);
        }

        if (!PlayerPrefs.HasKey("Music"))
        {
            MusicBarre.SetActive(false);
        }
        else
        {
            MusicBarre.SetActive(true);
        }
    }

    public void CheckVibrations()
    {
        if (vibrations == true)
        {
            vibrations = false;
            PlayerPrefs.SetInt("Vibrations", 1);
        } else if (vibrations == false)
        {
            vibrations = true;
            PlayerPrefs.DeleteKey("Vibrations");
        }
    }

    public void CheckSounds()
    {
        if (sound == true)
        {
            sound = false;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else if (sound == false)
        {
            sound = true;
            PlayerPrefs.DeleteKey("Sound");
        }
    }

    public void CheckMusics()
    {
        if (music == true)
        {
            music = false;
            PlayerPrefs.SetInt("Music", 1);
        }
        else if (music == false)
        {
            music = true;
            PlayerPrefs.DeleteKey("Music");
        }
    }
}
