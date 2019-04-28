using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class LevelValues : MonoBehaviour
{
    public int maxMissionTime;

    public Object SceneToLoad;

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

    [Header("Objectives")]
    public bool ObjectiveIsSelledBurger;
    [ShowIf("ObjectiveIsSelledBurger")]
    public List<int> SelledBurgerList;
    public int SelledBurger;


    public bool ObjectiveIsMoneyEarned;
    [ShowIf("ObjectiveIsMoneyEarned")]
    public List<int> MoneyEarnedList;
    public int earnedMoney;


    [Button]
    public void SendValues()
    {
        DetermineObjective();

        LevelValues_HolderStatic.maxMissionTime_holder = maxMissionTime;
        LevelValues_HolderStatic.minTime_Holded = minTime_Obstacle;
        LevelValues_HolderStatic.maxTime_Holded = maxTime_Obstacle;
        LevelValues_HolderStatic.decayTime_Holded = decayTime_Fuel;
        LevelValues_HolderStatic.LevelName_Holder = this.gameObject.name;
        LevelValues_HolderStatic.Scene = SceneToLoad;
        //SceneManager.LoadScene(SceneToLoad.name, LoadSceneMode.Single);
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

    public void Awake()
    {

        if (LevelValues_HolderStatic.LevelName_Holder == this.gameObject.name)
        {
            LastWin = LevelValues_HolderStatic.Win;
            if (LastWin)
            {
                StarOne = LevelValues_HolderStatic.StarOne;
                    StarTwo = LevelValues_HolderStatic.StarTwo;
                    StarThree = LevelValues_HolderStatic.StarThree;
            }
        }
    }
}

