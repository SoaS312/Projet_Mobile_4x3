using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTruckState : MonoBehaviour
{

    public bool isDriverActive = true;
    public bool isVigileActive;
    public bool isSellerActive;
    public bool isCookActive;
    public bool isHelicoActive;
    public bool isScooterActive;
    public static FoodTruckState staticFoodTruckState;


    [Header("Tuto Gauche")]
    public GameObject DriverTutoGauche;
    public GameObject CookTutoGauche;
    public GameObject VigileTutoGauche;

    [Header("Tuto Droite")]
    public GameObject DriverTutoDroite;
    public GameObject CookTutoDroite;
    public GameObject VigileTutoDroite;

    private void Awake()
    {
        staticFoodTruckState = this;
        isDriverActive = false;
        isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }

    public void ActivateDriver()
    {
        isDriverActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;

        if (RouteManager.Index == 0) {
            DriverTutoGauche.SetActive(true); CookTutoGauche.SetActive(false); VigileTutoGauche.SetActive(false); }
        else
        {
            DriverTutoDroite.SetActive(true); CookTutoDroite.SetActive(false); VigileTutoDroite.SetActive(false);
        }
    }
    public void ActivateVigile()
    {
        isVigileActive = true; isDriverActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        if (RouteManager.Index == 0)
        {
            DriverTutoGauche.SetActive(false); CookTutoGauche.SetActive(false); VigileTutoGauche.SetActive(true);
        }
        else
        {
            DriverTutoDroite.SetActive(false); CookTutoDroite.SetActive(false); VigileTutoDroite.SetActive(true);
        }
    }
    public void ActivateSeller()
    {
        isSellerActive = true; isVigileActive = false; isDriverActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        if (RouteManager.Index == 0)
        {
            DriverTutoGauche.SetActive(false); CookTutoGauche.SetActive(false); VigileTutoGauche.SetActive(false);
        }
        else
        {
            DriverTutoDroite.SetActive(false); CookTutoDroite.SetActive(false); VigileTutoDroite.SetActive(false);
        }
    }
    public void ActivateCook()
    {
        isCookActive = true; isVigileActive = false; isSellerActive = false; isDriverActive = false; isHelicoActive = false; isScooterActive = false;
        if (RouteManager.Index == 0)
        {
            DriverTutoGauche.SetActive(false); CookTutoGauche.SetActive(true); VigileTutoGauche.SetActive(false);
        }
        else
        {
            DriverTutoDroite.SetActive(false); CookTutoDroite.SetActive(true); VigileTutoDroite.SetActive(false);
        }
    }
    public void ActivateHelico()
    {
        isHelicoActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isDriverActive = false; isScooterActive = false;
        if (RouteManager.Index == 0)
        {
            DriverTutoGauche.SetActive(false); CookTutoGauche.SetActive(false); VigileTutoGauche.SetActive(false);
        }
        else
        {
            DriverTutoDroite.SetActive(false); CookTutoDroite.SetActive(false); VigileTutoDroite.SetActive(false);
        }
    }
    public void ActivateScooter()
    {
        isScooterActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isDriverActive = false;
        if (RouteManager.Index == 0)
        {
            DriverTutoGauche.SetActive(false); CookTutoGauche.SetActive(false); VigileTutoGauche.SetActive(false);
        }
        else
        {
            DriverTutoDroite.SetActive(false); CookTutoDroite.SetActive(false); VigileTutoDroite.SetActive(false);
        }
    }
}
