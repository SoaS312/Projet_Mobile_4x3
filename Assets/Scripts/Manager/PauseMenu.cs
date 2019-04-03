using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausedMenu;
    public bool isPaused;

    private Scene scene;

    public static PauseMenu staticPauseMenu;

    void Start()
    {
        staticPauseMenu = this;
        isPaused = false;
        Time.timeScale = 1f;
        PausedMenu.SetActive(false);
        scene = SceneManager.GetActiveScene();
    }


    public void OnApplicationPause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            PausedMenu.SetActive(true);
        }
        if (!isPaused)
        {
            Time.timeScale = 1f;
            PausedMenu.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        Application.LoadLevel(scene.name);
    }
    
    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }

}
