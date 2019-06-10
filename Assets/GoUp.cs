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
