﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour
{
    public static Cook staticCook;
    public GameObject FoodTruck;
    public int cookingProgress;
    public int maxCookingProgress;
    public int readyFood;
    public int maxReadyFood;
    public FoodStock foodStockManager;
    public int usedFoodByClick;
    public float actualTimer;
    public float MaxTimer = 0.5f;
    public Image foodProgress;
    public bool hasSwipeToLeft = false;
    public bool hasSwipeToRight = false;


    private void Start()
    {
        staticCook = this;
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

        if (actualTimer > 0)
        {
            actualTimer -= 1 * Time.deltaTime;
        }

        Cooking();
    }

    private void Cooking()
    {
        /*if( readyFood < maxReadyFood && foodStockManager.food > 0)
                            cookingProgress += 1;
                            foodStockManager.food -= usedFoodByClick;*/

        if (FoodTruckState.staticFoodTruckState.isCookActive)
        {
            if (SwipeLogger.staticSwipeLogger.stockedDirection == "Left" && readyFood < maxReadyFood && foodStockManager.food > 0 && actualTimer <= 0 && !hasSwipeToLeft)
            {
                hasSwipeToLeft = true;
                hasSwipeToRight = false;
                cookingProgress += 1;
                foodStockManager.food -= usedFoodByClick;
                actualTimer = MaxTimer;
            }
            if (SwipeLogger.staticSwipeLogger.stockedDirection == "Right" && readyFood < maxReadyFood && foodStockManager.food > 0 && actualTimer <= 0 && !hasSwipeToRight)
            {
                hasSwipeToRight = true;
                hasSwipeToLeft = false;
                cookingProgress += 1;
                foodStockManager.food -= usedFoodByClick;
                actualTimer = MaxTimer;
            }
        }
    }
}
