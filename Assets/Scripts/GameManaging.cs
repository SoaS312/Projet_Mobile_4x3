using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManaging : MonoBehaviour
{
    public static int NeverSleep;
    public GameObject WarningFuelGauche, WarningFuelDroite, WarningFoodGauche, WarningFoodDroite, WarningBothGauche, WarningBothDroite;

    public void Update()
    {

        if (FuelStock.staticFuelStock.fuel <= (FuelStock.staticFuelStock.maxFuel/3) && FoodStock.staticFoodStock.food > (FoodStock.staticFoodStock.maxFood / 3))
        {
            if (RouteManager.Index == 0)
            {
                WarningFuelDroite.SetActive(false);
                WarningFuelGauche.SetActive(true);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
            else if (RouteManager.Index == 1)
            {
                WarningFuelGauche.SetActive(false);
                WarningFuelDroite.SetActive(true);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
        }

        if (FoodStock.staticFoodStock.food <= (FoodStock.staticFoodStock.maxFood / 3) && FuelStock.staticFuelStock.fuel > (FuelStock.staticFuelStock.maxFuel / 3))
        {
            if (RouteManager.Index == 0)
            {
                WarningFuelDroite.SetActive(false);
                WarningFuelGauche.SetActive(false);
                WarningFoodGauche.SetActive(true);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
            else if (RouteManager.Index == 1)
            {
                WarningFuelGauche.SetActive(false);
                WarningFuelDroite.SetActive(false);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(true);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
        }

        if (FoodStock.staticFoodStock.food <= (FoodStock.staticFoodStock.maxFood / 3) && FuelStock.staticFuelStock.fuel <= (FuelStock.staticFuelStock.maxFuel / 3))
        {
            if (RouteManager.Index == 0)
            {
                WarningFuelDroite.SetActive(false);
                WarningFuelGauche.SetActive(false);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(true);
                WarningBothDroite.SetActive(false);
            }
            else if (RouteManager.Index == 1)
            {
                WarningFuelGauche.SetActive(false);
                WarningFuelDroite.SetActive(false);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(true);
            }
        }

        if (FoodStock.staticFoodStock.food > (FoodStock.staticFoodStock.maxFood / 3) && FuelStock.staticFuelStock.fuel > (FuelStock.staticFuelStock.maxFuel / 3) )
        {
            if (RouteManager.Index == 0)
            {
                WarningFuelDroite.SetActive(false);
                WarningFuelGauche.SetActive(false);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
            else if (RouteManager.Index == 1)
            {
                WarningFuelGauche.SetActive(false);
                WarningFuelDroite.SetActive(false);
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
            }

        if (FoodStock.staticFoodStock.food > (FoodStock.staticFoodStock.maxFood / 3))
        {
            if (RouteManager.Index == 0)
            {
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
            else if (RouteManager.Index == 1)
            {
                WarningFoodGauche.SetActive(false);
                WarningFoodDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
        }

        if (FuelStock.staticFuelStock.fuel > (FuelStock.staticFuelStock.maxFuel / 3))
        {
            if (RouteManager.Index == 0)
            {
                WarningFuelDroite.SetActive(false);
                WarningFuelGauche.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
            else if (RouteManager.Index == 1)
            {
                WarningFuelGauche.SetActive(false);
                WarningFuelDroite.SetActive(false);
                WarningBothGauche.SetActive(false);
                WarningBothDroite.SetActive(false);
            }
        }
    }


    void Awake()
    {
        Application.targetFrameRate = 120;
    }
}
