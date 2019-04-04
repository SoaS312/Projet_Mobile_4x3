using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodStockManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Update()
    {
        if (text)
            text.text = "" + Cook.staticCook.readyFood.ToString();
    }
}
