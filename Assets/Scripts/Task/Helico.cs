using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helico : MonoBehaviour
{
    public GameObject FoodTruck;
    public FuelStock FuelManager;
    public float fuelAmount = 2f;
    public int MoneyCost;
    public bool isHold = false;
    public float Timer;
    public float maxTimer = 0.05f;

    public CrewUpgradeScriptable HelicoLevel;

    private void Start()
    {
        fuelAmount = HelicoLevel.CrewUpgradeList[HelicoLevel.CrewLevelIndex];
    }


    public void Update()
    {
        if (Timer > 0)
            Timer -= 1 * Time.deltaTime;

        Wasting();
    }

    public void Holding()
    {
        isHold = true;
    }

    public void Release()
    {
        isHold = false;
    }

    public void Wasting()
    {
        if (ScoreManager.money >= MoneyCost && FoodTruckState.staticFoodTruckState.isHelicoActive)
        {
            ScoreManager.money -= 1;
        }
    }

    public void Buying()
    {
        if (ScoreManager.money >= MoneyCost && FoodTruckState.staticFoodTruckState.isHelicoActive)
        {
            FuelManager.fuel += fuelAmount * Time.deltaTime;
        }
    }
}
