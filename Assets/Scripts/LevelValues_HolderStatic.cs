using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelValues_HolderStatic : MonoBehaviour
{
    public static GameObject LevelValuesHolder;

    public static string LevelName_Holder;

    [Header("Obstacles Settings")]
    public static float minTime_Holded = 3;
    public static float maxTime_Holded = 6;

    [Header("Fuel Settings")]
    public static float decayTime_Holded = 2;

    [Header("BugerSell")]
    public static int SelledBurger_Holded;

    [Header("MoneyEarned")]
    public static int earnedMoney_Holded;

    public void Awake()
    {
        if (LevelValuesHolder == null)
        {
            LevelValuesHolder = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (LevelValuesHolder != this)
                {
            Destroy(gameObject);
        }
    }
}

