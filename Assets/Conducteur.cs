using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducteur : MonoBehaviour
{
    public GameObject FoodTruck;

    // Update is called once per frame
    void Update()
    {
        Driving();
    }

    private void Driving()
    {
        if (FoodTruckState.staticFoodTruckState.isDriverActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.name == "Route_Voie_01" || hit.transform.name == "Route_Voie_02")
                    {
                        Vector3 newPosition = FoodTruck.transform.position;
                        newPosition.z = hit.transform.position.z;
                        FoodTruck.transform.position = newPosition;

                    }

                }
            }
        }
    }
}