using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    public string SceneToLoad;
    public GameObject ButtonTap;
    public Animator Anim;

    void LaunchGameAfterAnim()
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }

    void ActiveTapping()
    {
        ButtonTap.SetActive(true);
    }

    public void TapToStart()
    {
        Anim.SetBool("Next", true);
    }
}
