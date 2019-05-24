using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuValue : MonoBehaviour
{

    public MainTitleCheck MainTitleManager;

    public void Awake()
    {
        MainTitleManager.MainMenuSkipped = false;
    }
}
