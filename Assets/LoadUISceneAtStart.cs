using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUISceneAtStart : MonoBehaviour
{
    public string UIScene;
    public string BigMenu;

    public void Start()
    {
        SceneManager.LoadScene(UIScene, LoadSceneMode.Additive);
    }

    public void KillME()
    {
        SceneManager.UnloadSceneAsync(BigMenu);
    }
}
