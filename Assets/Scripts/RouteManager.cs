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


    public float lerpTime = 1.5f;
    public float currentLerpTime = 0;


    [Header("Tuto Gauche")]
    public GameObject DriverTutoGauche;
    public GameObject CookTutoGauche;
    public GameObject VigileTutoGauche;
    public GameObject SellerTutoGauche;
    public GameObject ScooterTutoGauche;
    public GameObject HelicoTutoGauche;

    [Header("Tuto Droite")]
    public GameObject DriverTutoDroite;
    public GameObject CookTutoDroite;
    public GameObject VigileTutoDroite;
    public GameObject SellerTutoDroite;
    public GameObject ScooterTutoDroite;
    public GameObject HelicoTutoDroite;

    public void Awake()
    {
        staticRouteManager = this;
        FoodTruck.transform.position = new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z);
    }

    public void Move()
    {

        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        //transform.position = Vector3.Lerp(transform.position, new Vector3(VoiesRoutes[Index].transform.position.x, OffsetY, VoiesRoutes[Index].transform.position.z), currentLerpTime / lerpTime);

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
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(true);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(true);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
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
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(true);
                HelicoTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(true);
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
                SellerTutoGauche.SetActive(true);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(true);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
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
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
            }
            else
            {
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(true);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
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
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
            }
            else
            {
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(true);
                DriverTutoDroite.SetActive(false);
                DriverTutoGauche.SetActive(false);
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
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
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
            }
            else
            {
                DriverTutoDroite.SetActive(true);
                DriverTutoGauche.SetActive(false);
                CookTutoGauche.SetActive(false);
                CookTutoDroite.SetActive(false);
                VigileTutoGauche.SetActive(false);
                VigileTutoDroite.SetActive(false);
                SellerTutoGauche.SetActive(false);
                SellerTutoDroite.SetActive(false);
                ScooterTutoGauche.SetActive(false);
                ScooterTutoDroite.SetActive(false);
                HelicoTutoGauche.SetActive(false);
                HelicoTutoDroite.SetActive(false);
            }
        }
    }
}
