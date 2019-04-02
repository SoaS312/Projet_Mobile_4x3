using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helico : MonoBehaviour
{
    public GameObject FoodTruck;
    public FuelStock FuelManager;
    public int fuelAmount = 10;
    public int MoneyCost;

    void Update()
    {
        Buying();
    }

    private void Buying()
    {
        if (FuelManager.fuel < FuelManager.maxFuel && ScoreManager.money >= MoneyCost)
        {
            if (FoodTruckState.staticFoodTruckState.isHelicoActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject == FoodTruck)
                        {
                            FuelManager.fuel += fuelAmount;
                            ScoreManager.money -= MoneyCost;
                        }

                    }
                }
            }
        }
    }
}
