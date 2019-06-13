using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    public string SceneToLoad;

    void LaunchGameAfterAnim()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }
}
