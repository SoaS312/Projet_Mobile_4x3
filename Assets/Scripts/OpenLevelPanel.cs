﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class OpenLevelPanel : MonoBehaviour
{

    public GameObject Map, Cuisine;

    public void ShowElements()
    {
        Map.SetActive(true); Cuisine.SetActive(true);
    }

    public void HideElements()
    {
        Map.SetActive(false); Cuisine.SetActive(false);
    }

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
        this.gameObject.SetActive(false);
    }
}
