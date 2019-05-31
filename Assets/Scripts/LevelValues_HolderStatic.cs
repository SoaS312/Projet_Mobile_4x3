using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelValues_HolderStatic : MonoBehaviour
{


    public static GameObject LevelValuesHolder;
    public static string LevelName_Holder;



    public static int maxMissionTime_holder;
    public static string Scene;
    [Header("Obstacles Settings")]
    public static float minTime_Holded = 3;
    public static float maxTime_Holded = 6;

    [Header("Fuel Settings")]
    public static float decayTime_Holded = 0.5f;

    [Header("Ojectives")]
    public static bool Win;
    public static string WhichObjective;
    public static List<int> ObjectiveKeys;

    [Header("BugerSell")]
    public static int SelledBurger_Holded;

    [Header("MoneyEarned")]
    public static int earnedMoney_Holded;

    [Header("Stars")]
    public static bool StarOne;
    public static bool StarTwo;
    public static bool StarThree;
    public static int staticUnlockedStars;

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

