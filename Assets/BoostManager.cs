using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class BoostManager : MonoBehaviour
{
    public bool isInvicible, isUndryiable, isAutoCokking, isInfiniteFood;
    public float timer, maxTime;

    public float cookTime, maxCookTime;

    public GameObject FoodTruck;

    public void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 0;
            isInvicible = isUndryiable = isAutoCokking = isInfiniteFood = false;
        }

        Invincible();

        Undryiable();

        AutoCook();

        InfiniteFood();

    }

    private void InfiniteFood()
    {
        if (isInfiniteFood)
        {
            if (timer > 0)
            {
                FoodStock.staticFoodStock.food = FoodStock.staticFoodStock.maxFood;
            }
        }
    }

    [Button]
    public void SetTime()
    {
        timer = maxTime;
    }

    private void AutoCook()
    {
        if (isAutoCokking)
        {
            if (timer > 0)
            {
                if (cookTime < maxCookTime)
                {
                    cookTime += Time.deltaTime;
                }

                if (cookTime >= maxCookTime)
                {
                    Cook.staticCook.cookingProgress += 1;
                    cookTime = 0;
                }
            }
        }
    }

    private void Undryiable()
    {
        if (isUndryiable)
        {
            if (timer > 0)
            {
                FuelStock.staticFuelStock.fuel = FuelStock.staticFuelStock.maxFuel;
                FuelStock.staticFuelStock.decayTime = 0;
            }
        }

        if (timer <= 0)
        {
            FuelStock.staticFuelStock.decayTime = LevelValues_HolderStatic.decayTime_Holded;
        }
    }

    private void Invincible()
    {
        if (isInvicible)
        {
            if(timer > 0)
            {
                FoodTruck.GetComponent<Collider>().enabled = false;
            }
        }

        if (timer <= 0)
        {
            FoodTruck.GetComponent<Collider>().enabled = true;
        }
    }
}
