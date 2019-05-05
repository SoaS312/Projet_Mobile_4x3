using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScreen : MonoBehaviour
{
    void Start()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

}
