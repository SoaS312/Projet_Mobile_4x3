using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [Range(0,100)]
    public float speed = 5;

    void Update()
    {
        LooseIsReal();
    }

    private void LooseIsReal()
    {
        if (!PauseMenu.staticPauseMenu.isPaused)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (PauseMenu.staticPauseMenu.isPaused)
            transform.Translate(Vector3.zero);
    }
}