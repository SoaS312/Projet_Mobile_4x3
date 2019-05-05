using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helico : MonoBehaviour
{
    public GameObject FoodTruck;
    public FuelStock FuelManager;
    public int fuelAmount = 10;
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
        Buying();

        if (Timer > 0)
            Timer -= 1 * Time.deltaTime;
    }

    public void Holding()
    {
        isHold = true;
    }

    public void Release()
    {
        isHold = false;
    }

    public void Buying()
    {
        if (FuelManager.fuel < FuelManager.maxFuel && ScoreManager.money >= MoneyCost && isHold && Timer <= 0)
        {
            FuelManager.fuel += fuelAmount;
            ScoreManager.money -= MoneyCost;
            Timer = maxTimer;
        }
    }
}
