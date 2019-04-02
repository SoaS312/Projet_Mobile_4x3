using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodStockManager : MonoBehaviour
{
    public Cook ReadyFoodStock;
    public Text text;                      // Reference to the Text component.

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = ReadyFoodStock.readyFood +"/" + ReadyFoodStock.maxReadyFood ;
    }
}
