using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    public GameObject GameManager;

    public bool Loose = false;

    public void Update()
    {
        if(GameManager.GetComponent<FuelStock>().fuel <= 0)
        {
            Debug.Log("T'as perdu.");
            Loose = true;
        }
    }
}
