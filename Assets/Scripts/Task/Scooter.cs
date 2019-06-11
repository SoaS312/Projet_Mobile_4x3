using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter : MonoBehaviour
{
    public GameObject FoodTruck;
    public FoodStock foodStockManager;
    public static Scooter staticScooter;
    public int MoneyCost;
    public int foodAmount = 1;
    public float Timer;
    public float maxTimer = 0.05f;

    public bool hasResettedTime = false, wasInPos = false;

    public CrewUpgradeScriptable ScooterLevel;

    public GameObject ScooterObj;
    public Transform StartPos;
    public Transform ActualPos;
    public Transform ChosenPlace;

    public float lerpTime = 2; // Time it takes to reach
    public float currentCOMELerpTime = 0;

    public float currentLEAVELerpTime = 0;

    public Transform ScooterPosGauche;
    public Transform ScooterPosDroite;

    [Header("Settings")]
    public float timer;
    public float minTime;
    public float maxTime;

    [Header("===PrepFood===")]
    public List<GameObject> PrepFoodList;
    public GameObject FoodSelected;


    private void Start()
    {
        lerpTime = 0.75f;
        StartPos = FollowersManager.staticFollowersManager.transform;
        staticScooter = this;
        foodAmount = ScooterLevel.CrewUpgradeList[ScooterLevel.CrewLevelIndex];
        timer = Random.Range(minTime, maxTime);
    }


    void Update()
    {
        if(RouteManager.Index <= 0)
        {
            ChosenPlace = ScooterPosGauche;
        }

        else if (RouteManager.Index >= 1)
        {
            ChosenPlace = ScooterPosDroite;
        }

        if (currentCOMELerpTime < lerpTime && FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            currentCOMELerpTime += Time.deltaTime;
        }

        if (currentCOMELerpTime >= lerpTime)
        {
            currentCOMELerpTime = lerpTime;
            wasInPos = true;
        }


        if (currentLEAVELerpTime < lerpTime && !FoodTruckState.staticFoodTruckState.isScooterActive && wasInPos)
        {
            currentLEAVELerpTime += Time.deltaTime;
        }

        if (currentLEAVELerpTime >= lerpTime)
        {
            currentLEAVELerpTime = lerpTime;
            wasInPos = false;
            currentCOMELerpTime = 0;
            currentLEAVELerpTime = 0;
        }

        MoveToPosition();
        ReturnToStart();


        if (timer > 0 && FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && ScoreManager.money > Scooter.staticScooter.MoneyCost)
        {
            int index = Random.Range(0, PrepFoodList.Count);
            FoodSelected = PrepFoodList[index];
            FoodSelected.transform.position = ScooterObj.transform.position;
            FoodSelected.SetActive(true);
            PrepFoodList.Remove(FoodSelected);
            timer = Random.Range(minTime, maxTime);
        }
    }

    public void MoveToPosition() { 

        if (FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            hasResettedTime = false;
            ScooterObj.transform.position = Vector3.Lerp(StartPos.position, ChosenPlace.position, currentCOMELerpTime/lerpTime);
        }
    }

    public void ReturnToStart()
    {
        if (!FoodTruckState.staticFoodTruckState.isScooterActive && wasInPos)
        {
            ScooterObj.transform.position = Vector3.Lerp(ChosenPlace.position, StartPos.position, currentLEAVELerpTime / lerpTime);
        }
    }
}
