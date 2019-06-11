using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LetsGo : MonoBehaviour
{
    public UnityEvent myEvent;
    public bool clicked = false, Paused = true;

    public float seconds, maxSeconds = 3;

    public void Click()
    {
        clicked = true;
        seconds = maxSeconds;
    }

    public void Update()
    {
        if(seconds > 0 && clicked)
        {
            seconds -= Time.unscaledDeltaTime;
        }

        if (seconds <= 0 && clicked && Paused)
        {
            myEvent.Invoke();
            Paused = false;
        }
    }
}
