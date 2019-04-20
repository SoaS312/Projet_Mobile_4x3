using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conducteur : MonoBehaviour
{
    public GameObject FoodTruck;
    public float actualTimer;
    public float MaxTimer = 0.5f;
    public static Conducteur staticConducteur;

    private void Awake()
    {
        staticConducteur = this;
    }

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