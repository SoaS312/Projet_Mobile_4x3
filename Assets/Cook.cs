using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour
{
    public GameObject FoodTruck;
    public int cookingProgress;
    public int maxCookingProgress;
    public int readyFood;
    public int maxReadyFood;
    public FoodStock foodStockManager;

    public Image foodProgress;


    private void Start()
    {
        cookingProgress = 0;
    }

    void Update()
    {
        Cooking();

        if (cookingProgress == maxCookingProgress)
        {
            cookingProgress = 0;
            readyFood += 1;
        }

        foodProgress.fillAmount = (float)cookingProgress / (float)maxCookingProgress;

    }

    private void Cooking()
    {
        if( readyFood < maxReadyFood && foodStockManager.food > 0) { 
        if (FoodTruckState.staticFoodTruckState.isCookActive)
        {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject == FoodTruck)
                        {
                            cookingProgress += 1;
                            foodStockManager.food -= 1;
                        }

                    }
                }
            }
        }
    }
}
