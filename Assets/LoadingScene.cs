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
    public Text DebugTextSceneName;
    public Text DebugTextothervalue;

    public void Start()
    {
        DebugTextothervalue.text = "Valeur random" + LevelValues_HolderStatic.maxMissionTime_holder;
        StartCoroutine(LoadingScreen());
        DebugTextSceneName.text = "Nom de scene " + LevelValues_HolderStatic.Scene;
    }

    IEnumerator LoadingScreen()
    {
       yield return new WaitForSeconds(1f);
        //async = SceneManager.LoadSceneAsync("US_Level_Joris");
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
