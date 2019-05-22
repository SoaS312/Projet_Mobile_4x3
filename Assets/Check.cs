using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{

    public MainTitleCheck MainTitleManager;
    public bool condition;

    void Update()
    {

        if (MainTitleManager.MainMenuSkipped)
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(condition);
        }
    }

}
