using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    public float Timer;
    public float MaxTime;
    public Sprite EssencePlus, FoodPlus, MoneyPlus, LunchesPlus;

    public void Start()
    {
        Timer = 0;
        CheckSprite();
    }

    private void CheckSprite()
    {
        if (FoodTruckState.staticFoodTruckState.isCookActive)
        {
            GetComponent<SpriteRenderer>().sprite = LunchesPlus;
        }
        if (FoodTruckState.staticFoodTruckState.isSellerActive)
        {
            GetComponent<SpriteRenderer>().sprite = MoneyPlus;
        }
        if (FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            GetComponent<SpriteRenderer>().sprite = FoodPlus;
        }
        if (FoodTruckState.staticFoodTruckState.isHelicoActive)
        {
            GetComponent<SpriteRenderer>().sprite = EssencePlus;
        }
    }

    void Update()
    {
        if (Timer < MaxTime)
        {
            Timer += 1*Time.deltaTime;
        } else if (Timer > MaxTime)
        {
            Timer = MaxTime;
        }

        if (Timer == MaxTime)
        {
            gameObject.SetActive(false);
        }

        transform.position += transform.up * Time.deltaTime;
    }
}
