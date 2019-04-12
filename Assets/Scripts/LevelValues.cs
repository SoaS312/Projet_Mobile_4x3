using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class LevelValues : MonoBehaviour
{
    public int Timer;

    public Object SceneToLoad;

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
        LevelValues_HolderStatic.minTime_Holded = minTime_Obstacle;
        LevelValues_HolderStatic.maxTime_Holded = maxTime_Obstacle;
        LevelValues_HolderStatic.decayTime_Holded = decayTime_Fuel;
        LevelValues_HolderStatic.LevelName_Holder = this.gameObject.name;
        SceneManager.LoadScene(SceneToLoad.name, LoadSceneMode.Single);
    }

    public void Awake()
    {
        if (LevelValues_HolderStatic.LevelName_Holder == this.gameObject.name)
        {
            if (ObjectiveIsSelledBurger) { 
            SelledBurger = LevelValues_HolderStatic.SelledBurger_Holded;
            BurgerObjective();
        }
            if (ObjectiveIsMoneyEarned)
            {
                earnedMoney = LevelValues_HolderStatic.earnedMoney_Holded;
                MoneyObjective();
            }


        }
    }

    private void MoneyObjective()
    {
        if (earnedMoney >= MoneyEarnedList[0])
        {
            StarOne = true;
        }
        if (earnedMoney >= MoneyEarnedList[1])
        {
            StarTwo = true;
        }
        if (earnedMoney >= MoneyEarnedList[2])
        {
            StarThree = true;
        }
    }

    private void BurgerObjective()
    {
            if (SelledBurger >= SelledBurgerList[0])
            {
                StarOne = true;
            }
            if (SelledBurger >= SelledBurgerList[1])
            {
                StarTwo = true;
            }
            if (SelledBurger >= SelledBurgerList[2])
            {
                StarThree = true;
            }
    }
}

