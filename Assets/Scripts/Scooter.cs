using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : MonoBehaviour
{
    public GameObject FoodTruck;
    public FoodStock foodStockManager;
    public int MoneyCost;
    public int foodAmount = 1;

    void Update()
    {
        Buying();
    }

    private void Buying()
    {
        if (foodStockManager.food < foodStockManager.maxFood && ScoreManager.money >= MoneyCost)
        {
            if (FoodTruckState.staticFoodTruckState.isScooterActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject == FoodTruck)
                        {
                            foodStockManager.food += foodAmount; ;
                            ScoreManager.money -= MoneyCost;
                        }

                    }
                }
            }
        }
    }
}
