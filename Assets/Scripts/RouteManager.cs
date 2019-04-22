using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{

    public List<GameObject> VoiesRoutes;
    public static int Index;
    public GameObject FoodTruck;
    public float OffsetY = 0.6f;
    public static RouteManager staticRouteManager;

    public void Awake()
    {
        staticRouteManager = this;
    }

    public void Update()
    {
        if(Index > 1)
        {
            Index = 1;
        }

        FoodTruck.transform.position = new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z);
    }

}
