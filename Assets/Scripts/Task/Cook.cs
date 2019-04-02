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
    public int usedFoodByClick;

    public Image foodProgress;


    private void Start()
    {
        cookingProgress = 0;
    }

    void Update()
    {
        if (cookingProgress == maxCookingProgress)
        {
            cookingProgress = 0;
            readyFood += 1;
        }

        foodProgress.fillAmount = (float)cookingProgress / (float)maxCookingProgress;

    }

    public void Cooking()
    {
        if( readyFood < maxReadyFood && foodStockManager.food > 0)
                            cookingProgress += 1;
                            foodStockManager.food -= usedFoodByClick;
    }
}
