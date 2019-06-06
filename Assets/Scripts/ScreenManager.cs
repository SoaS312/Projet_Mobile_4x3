using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        if (Application.isMobilePlatform)
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
