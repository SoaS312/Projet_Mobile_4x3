using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [Range(0,100)]
    public int speed = 5;

    void Update()
    {
        if (!PauseMenu.staticPauseMenu.isPaused)
            transform.Translate(Vector3.left * speed / 100);
        else transform.Translate(Vector3.zero);
    }
}
