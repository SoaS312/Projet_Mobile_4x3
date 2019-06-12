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
    public GameObject WarningFuelGauche, WarningFuelDroite;

    [Range(0, 10f)]
    public float decayTime;
    public GameObject ValuesHolder;

    public CrewUpgradeScriptable DriverLevel;

    private void Awake()
    {
        ValuesHolder = LevelValues_HolderStatic.LevelValuesHolder;
    }

    void Start()
    {
        staticFuelStock = this;
        maxFuel = DriverLevel.CrewUpgradeList[DriverLevel.CrewLevelIndex];
        fuel = maxFuel;
        isDry = false;
        decayTime = LevelValues_HolderStatic.decayTime_Holded;
    }

    void Update()
    {
        stockFuel.fillAmount = fuel / maxFuel;

        if (fuel <= (maxFuel/3))
        {
            if(RouteManager.Index == 0)
            {
                WarningFuelDroite.SetActive(false);
                WarningFuelGauche.SetActive(true);
            } else if (RouteManager.Index == 1)
            {
                WarningFuelGauche.SetActive(false);
                WarningFuelDroite.SetActive(true);
            }
        }

       fuel -= Time.deltaTime*decayTime;

        if (fuel <= 0)
        {
            fuel = 0;
            isDry = true;
        }


        if (fuel > maxFuel)
        {
            fuel = maxFuel;
        }
    }
}
