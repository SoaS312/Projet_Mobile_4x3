using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeLevel : MonoBehaviour
{
    public void FadeIn()
    {
        GetComponent<Animator>().SetBool("FadeIn", true);
        GetComponent<Animator>().SetBool("FadeOut", false);
    }

    public void FadeOut()
    {
        GetComponent<Animator>().SetBool("FadeOut", true);
        GetComponent<Animator>().SetBool("FadeIn", false);
    }
}
