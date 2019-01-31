using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTruckState : MonoBehaviour
{

    public bool isDriverActive = true;
    public bool isVigileActive;
    public bool isSellerActive;
    public bool isCookActive;
    public bool isHelicoActive;
    public bool isScooterActive;
    public static FoodTruckState staticFoodTruckState;

    private void Awake()
    {
        staticFoodTruckState = this;
        isDriverActive = true;
        isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }

    public void ActivateDriver()
    {
        isDriverActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }
    public void ActivateVigile()
    {
        isVigileActive = true; isDriverActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }
    public void ActivateSeller()
    {
        isSellerActive = true; isVigileActive = false; isDriverActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }
    public void ActivateCook()
    {
        isCookActive = true; isVigileActive = false; isSellerActive = false; isDriverActive = false; isHelicoActive = false; isScooterActive = false;
    }
    public void ActivateHelico()
    {
        isHelicoActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isDriverActive = false; isScooterActive = false;
    }
    public void ActivateScooter()
    {
        isScooterActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isDriverActive = false;
    }
}
