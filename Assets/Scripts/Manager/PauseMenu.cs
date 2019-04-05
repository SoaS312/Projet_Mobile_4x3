using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausedMenu;
    public bool isPaused;
    public bool needPause;

    private Scene scene;

    public static PauseMenu staticPauseMenu;

    void Start()
    {
        staticPauseMenu = this;
        isPaused = true;
        needPause = false;
        Time.timeScale = 0f;
        //PausedMenu.SetActive(true);
        scene = SceneManager.GetActiveScene();
    }


    public void OnApplicationPause()
    {
        isPaused = !isPaused;

        if (isPaused && needPause)
        {
            Time.timeScale = 0f;
            PausedMenu.SetActive(true);
        }
        if (!isPaused && needPause)
        {
            Time.timeScale = 1f;
            PausedMenu.SetActive(false);
        }
    }

    public void NeedPauseFunction()
    {
        Time.timeScale = 1f;
        if (needPause == false)
        needPause = true;
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
