﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStockManager : MonoBehaviour
{
    public Cook ReadyFoodStock;
    public TextMeshProUGUI text;

    void Update()
    {
        text.text = "" + ReadyFoodStock.readyFood.ToString();
    }
}
