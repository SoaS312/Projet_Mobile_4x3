using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodStock : MonoBehaviour
{

    public static FoodStock staticFoodStock;
    public float food;
    public float maxFood;
    public Image stockFood;


    void Awake()
    {
        staticFoodStock = this;
        food = maxFood; 
    }

    void Update()
    {
        stockFood.fillAmount = food / maxFood;

        if (food > maxFood)
        {
            food = maxFood;
        }


        if (food < 0)
        {
            food = 0;
        }
        
    }
}
