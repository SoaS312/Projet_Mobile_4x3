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

    // Start is called before the first frame update
    void Awake()
    {
        food = maxFood; 
    }

    // Update is called once per frame
    void Update()
    {
        stockFood.fillAmount = food / maxFood;

        if (food < 0)
        {
            food = 0;
        }
        
    }
}
