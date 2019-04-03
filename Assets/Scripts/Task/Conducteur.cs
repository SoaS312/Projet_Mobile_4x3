using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducteur : MonoBehaviour
{
    public GameObject FoodTruck;
    public float actualTimer;
    public float MaxTimer = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Driving();

        if (actualTimer > 0)
        {
            actualTimer -= 1*Time.deltaTime;
        }
    }

    private void Driving()
    {
        if (FoodTruckState.staticFoodTruckState.isDriverActive)
        {
            /*if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
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
            }*/
           if (SwipeLogger.staticSwipeLogger.stockedDirection == "Left" && RouteManager.staticRouteManager.Index < RouteManager.staticRouteManager.VoiesRoutes.Count && actualTimer <= 0)
            {
                RouteManager.staticRouteManager.Index += 1;
                actualTimer = MaxTimer;
                SwipeLogger.staticSwipeLogger.stockedDirection = "clean";
            }
            if (SwipeLogger.staticSwipeLogger.stockedDirection == "Right" && RouteManager.staticRouteManager.Index > 0 && actualTimer <= 0)
            {
                RouteManager.staticRouteManager.Index -= 1;
                actualTimer = MaxTimer;
                SwipeLogger.staticSwipeLogger.stockedDirection = "clean";
            }
        }
    }
}