using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{
    public static int NeverSleep;

    void Awake()
    {
        Application.targetFrameRate = 120;
    }
}
