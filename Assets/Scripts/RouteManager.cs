using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteManager : MonoBehaviour
{

    public List<GameObject> VoiesRoutes;
    public int Index;
    public GameObject FoodTruck;
    public float OffsetY;
    public static RouteManager staticRouteManager;

    public void Awake()
    {
        staticRouteManager = this;
    }

    public void Update()
    {
        FoodTruck.transform.position = new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z);
    }

}
