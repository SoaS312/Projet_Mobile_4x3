using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreenObj;
    public Image filling;
    AsyncOperation async;

    public void Start()
    {
        StartCoroutine(LoadingScreen());
        if(Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(1f);
        async = SceneManager.LoadSceneAsync(LevelValues_HolderStatic.Scene);
        async.allowSceneActivation = false;
        filling.fillAmount += 0.05f;

        while (async.isDone == false)
        {
            filling.fillAmount = async.progress;
            if(async.progress == 0.9f)
            {
                filling.fillAmount = 1f;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
