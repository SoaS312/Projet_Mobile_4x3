using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject GameManager;
    public int FuelEnMoins;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            GameManager.GetComponent<FuelStock>().fuel -= FuelEnMoins;
        }
    }
}
