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
           if (SwipeLogger.staticSwipeLogger.stockedDirection == "Left" && RouteManager.Index < RouteManager.staticRouteManager.VoiesRoutes.Count && actualTimer <= 0)
            {
                if (RouteManager.Index < 1)
                    RouteManager.Index += 1;

                RouteManager.staticRouteManager.Move();
                actualTimer = MaxTimer;
                Debug.Log("Gauche");
            }
            if (SwipeLogger.staticSwipeLogger.stockedDirection == "Right" && RouteManager.Index > 0 && actualTimer <= 0)
            {
                if (RouteManager.Index>0)
                RouteManager.Index -= 1;

                RouteManager.staticRouteManager.Move();
                actualTimer = MaxTimer;
                Debug.Log("Droite");
            }
        }
    }
}