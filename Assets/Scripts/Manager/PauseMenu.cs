using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public bool isPaused;

    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }


    public void OnApplicationPause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        if (!isPaused)
        {
            Time.timeScale = 1f;
        }
    }
}
