using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChallengesPanel : MonoBehaviour
{
    public GameObject Tab1, Tab2;

    public void Show()
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Animator>().SetBool("Show", true);
        this.gameObject.GetComponent<Animator>().SetBool("Hide", false);
    }

    public void Hide()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Show", false);
        this.gameObject.GetComponent<Animator>().SetBool("Hide", true);
    }


    public void Disable()
    {
        this.gameObject.SetActive(true);
        Tab1.SetActive(true); Tab2.SetActive(true);
    }
}
