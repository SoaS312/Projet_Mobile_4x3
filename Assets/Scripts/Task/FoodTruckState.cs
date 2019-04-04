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

    public GameObject DriverTuto;
    public GameObject CookTuto;
    public GameObject VigileTuto;

    private void Awake()
    {
        staticFoodTruckState = this;
        isDriverActive = false;
        isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }

    public void ActivateDriver()
    {
        isDriverActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        DriverTuto.SetActive(true); CookTuto.SetActive(false); VigileTuto.SetActive(false);
    }
    public void ActivateVigile()
    {
        isVigileActive = true; isDriverActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        DriverTuto.SetActive(false); CookTuto.SetActive(false); VigileTuto.SetActive(true);
    }
    public void ActivateSeller()
    {
        isSellerActive = true; isVigileActive = false; isDriverActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        DriverTuto.SetActive(false); CookTuto.SetActive(false); VigileTuto.SetActive(false);
    }
    public void ActivateCook()
    {
        isCookActive = true; isVigileActive = false; isSellerActive = false; isDriverActive = false; isHelicoActive = false; isScooterActive = false;
        DriverTuto.SetActive(false); CookTuto.SetActive(true); VigileTuto.SetActive(false);
    }
    public void ActivateHelico()
    {
        isHelicoActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isDriverActive = false; isScooterActive = false;
        DriverTuto.SetActive(false); CookTuto.SetActive(false); VigileTuto.SetActive(false);
    }
    public void ActivateScooter()
    {
        isScooterActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isDriverActive = false;
        DriverTuto.SetActive(false); CookTuto.SetActive(false); VigileTuto.SetActive(false);
    }
}
