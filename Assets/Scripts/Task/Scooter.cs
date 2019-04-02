using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : MonoBehaviour
{
    public GameObject FoodTruck;
    public FoodStock foodStockManager;
    public int MoneyCost;
    public int foodAmount = 1;
    public bool isHold = false;
    public float Timer;
    public float maxTimer = 0.05f;

    void Update()
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

    private void Buying()
    {
        if (foodStockManager.food < foodStockManager.maxFood && ScoreManager.money >= MoneyCost && isHold && Timer <= 0)
        {

                            foodStockManager.food += foodAmount; ;
                            ScoreManager.money -= MoneyCost;
                            Timer = maxTimer;
        }
    }
}
