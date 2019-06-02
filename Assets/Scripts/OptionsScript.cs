using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    public bool vibrations = true;

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
}
