﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelStock : MonoBehaviour
{
    public static FuelStock staticFuelStock;
    public float fuel;
    public float maxFuel;
    public bool isDry;
    public Image stockFuel;
    [Range(0, 10f)]
    public float decayTime;

    void Start()
    {
        staticFuelStock = this;
        fuel = maxFuel;
        isDry = false;
    }

    void Update()
    {
        stockFuel.fillAmount = fuel / maxFuel;


       fuel -= Time.deltaTime*decayTime;

        if (fuel <= 0)
        {
            fuel = 0;
            isDry = true;
        }
    }
}
