using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewLevel", menuName = "Levels/NewLevel")]
public class LevelValuesScriptable : ScriptableObject
{
    public int maxMissionTime;
    
    public string SceneName;

    public bool LastWin;

    [Header("Obstacles Settings")]
    public float minTime_Obstacle;
    public float maxTime_Obstacle;

    [Header("Fuel Settings")]
    public float decayTime_Fuel;

    [Header("STARS")]
    public bool StarOne;
    public bool StarTwo;
    public bool StarThree;
    public int unlockedStars;

    [Header("Objectives")]
    public bool ObjectiveIsSelledBurger;
    [ShowIf("ObjectiveIsSelledBurger")]
    public List<int> SelledBurgerList;
    public int SelledBurger;


    public bool ObjectiveIsMoneyEarned;
    [ShowIf("ObjectiveIsMoneyEarned")]
    public List<int> MoneyEarnedList;
    public int earnedMoney;



    [Header("Unlockable")]
    public bool isUnlocked = false;
    public LevelValuesScriptable previousLevel;


    public void Awake()
    {
        if(previousLevel.unlockedStars > 0)
        {
            isUnlocked = true;
        }




        CheckStar();
        if (LevelValues_HolderStatic.LevelName_Holder == name)
        {
            LastWin = LevelValues_HolderStatic.Win;
            if (LastWin)
            {
                if (unlockedStars < LevelValues_HolderStatic.staticUnlockedStars)
                unlockedStars = LevelValues_HolderStatic.staticUnlockedStars;
                CheckStar();
            }
        }
        CheckStar();
    }


    public void Start()
    {
        CheckStar();
        if (LastWin)
        {
            CheckStar();
            SaveLoad.staticSaveLoad.SavingStars();
            Debug.Log("Saved");
        }
        CheckStar();
        if (!LastWin)
        {
            CheckStar();
            SaveLoad.staticSaveLoad.LoadingStars();
            CheckStar();
            Debug.Log("Loaded");
        }
        CheckStar();
    }

    public void SendValues()
    {
        DetermineObjective();
        LevelValues_HolderStatic.Scene = SceneName;
        LevelValues_HolderStatic.maxMissionTime_holder = maxMissionTime;
        LevelValues_HolderStatic.minTime_Holded = minTime_Obstacle;
        LevelValues_HolderStatic.maxTime_Holded = maxTime_Obstacle;
        LevelValues_HolderStatic.decayTime_Holded = decayTime_Fuel;
        LevelValues_HolderStatic.LevelName_Holder = name;
        LevelValues_HolderStatic.StarOne = StarOne;
        LevelValues_HolderStatic.StarTwo = StarTwo;
        LevelValues_HolderStatic.StarThree = StarThree;
    }

    private void DetermineObjective()
    {
        if (ObjectiveIsSelledBurger)
        {
            LevelValues_HolderStatic.WhichObjective = "Burger";
            LevelValues_HolderStatic.ObjectiveKeys = SelledBurgerList;
        }
        if (ObjectiveIsMoneyEarned)
        {
            LevelValues_HolderStatic.WhichObjective = "Money";
            LevelValues_HolderStatic.ObjectiveKeys = MoneyEarnedList;
        }
    }

    public void CheckStar()
    {
        if (unlockedStars == 0 && unlockedStars < 1 && unlockedStars< 2 && unlockedStars < 3)
        {
            StarOne = false;
            StarTwo = false;
            StarThree = false;
        }

        if (unlockedStars == 1 && unlockedStars < 2 && unlockedStars < 3)
        {
            StarOne = true;
            StarTwo = false;
            StarThree = false;
        }

        if (unlockedStars == 2 && unlockedStars < 3)
        {
            StarOne = true;
            StarTwo = true;
            StarThree = false;
        }

        if (unlockedStars >= 3)
        {
            StarOne = true;
            StarTwo = true;
            StarThree = true;
        }
    }
}


