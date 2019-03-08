﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public int index;
    public Material Color;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > (0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.transform.name)
                {
                    gameObject.GetComponent<MeshRenderer>().material = Color; 
                    SceneManager.LoadScene(index);
                }
            }
        }
    }
}