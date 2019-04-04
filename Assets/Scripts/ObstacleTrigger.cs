using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ObstacleTrigger : MonoBehaviour
{
    [HideIf("isObstacle")]
    public bool isBonus = false;
    [HideIf("isBonus")]
    public bool isObstacle = false;

    [ShowIf("isBonus")]
    public bool isFuelBonus;
    [ShowIf("isBonus")]
    public bool isFoodBonus;
    [ShowIf("isBonus")]
    public bool isMoneyBonus;
    [ShowIf("isBonus")]
    public bool isInvicibleBonus;
    [ShowIf("isBonus")]
    public bool isAutoCookBonus;

    [ShowIf(ConditionOperator.Or, "isObstacle", "isFuelBonus")]
    public int FuelValue;

    [ShowIf("isFoodBonus")]
    public int FoodValue;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FoodTruck" && isObstacle)
        {
            FuelStock.staticFuelStock.fuel -= FuelValue;
            Destroy(gameObject);
        }
        else
        if (other.tag == "FoodTruck" && isBonus && isFuelBonus)
        {
            FuelStock.staticFuelStock.fuel += FuelValue;
            Destroy(gameObject);
        }
        else
        if (other.tag == "FoodTruck" && isBonus && isFoodBonus)
        {
            FoodStock.staticFoodStock.food += FoodValue;
            Destroy(gameObject);
        }
    }
}
