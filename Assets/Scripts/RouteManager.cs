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


    [Header("Tuto Gauche")]
    public GameObject DriverTutoGauche;
    public GameObject CookTutoGauche;
    public GameObject VigileTutoGauche;

    [Header("Tuto Droite")]
    public GameObject DriverTutoDroite;
    public GameObject CookTutoDroite;
    public GameObject VigileTutoDroite;

    public void Awake()
    {
        staticRouteManager = this;
        FoodTruck.transform.position = new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z);
    }

    public void Move()
    {
        FoodTruck.transform.position = new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z);
        //FoodTruck.transform.position = Vector3.MoveTowards(transform.position, new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z), 1 * Time.deltaTime);
    }

    public void Update()
    {
        if (Index > 1)
        {
            Index = 1;
        }

        IfDriverisActive();
        IfCookisActive();
        IfVigileisActive();
        IfSellerisActive();
        IfHelicoisActive();
        IfScooterisActive();

    }

    private void IfScooterisActive()
    {
        if (FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            if (Index == 0)
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                DriverTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
            }
        }
    }

    private void IfHelicoisActive()
    {
        if (FoodTruckState.staticFoodTruckState.isHelicoActive)
        {
            if (Index == 0)
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                DriverTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
            }
        }
    }

    private void IfSellerisActive()
    {
        if (FoodTruckState.staticFoodTruckState.isSellerActive)
        {
            if (Index == 0)
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                DriverTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
            }
        }
    }

    private void IfVigileisActive()
    {
        if (FoodTruckState.staticFoodTruckState.isVigileActive)
        {
            if (Index == 0)
            {
                VigileTutoGauche.SetActive(true);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                DriverTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(true);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
            }
        }
    }

    private void IfCookisActive()
    {
        if (FoodTruckState.staticFoodTruckState.isCookActive)
        {
            if (Index == 0)
            {
                CookTutoGauche.SetActive(true);
                CookTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                DriverTutoDroite.SetActive(false);
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
            }
            else
            {
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(true);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
            }
        }
    }

    private void IfDriverisActive()
    {
        if (FoodTruckState.staticFoodTruckState.isDriverActive)
        {
            if (Index == 0)
            {
                DriverTutoGauche.SetActive(true);
                DriverTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
            }
            else
            {
                DriverTutoDroite.SetActive(true);
                DriverTutoGauche.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
            }
        }
    }
}
