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
    public Transform ChosenPlace;

    public float lerpTime = 5; // Time it takes to reach
    public float currentLerpTime = 0;
        
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
        StartPos = ScooterObj.transform;
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


        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        MoveToPosition();
        ReturnToStart();


        if (timer > 0 && FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            int index = Random.Range(0, PrepFoodList.Count);
            FoodSelected = PrepFoodList[index];
            FoodSelected.transform.position = ScooterObj.transform.position;
            FoodSelected.SetActive(true);
            PrepFoodList.Remove(FoodSelected);
            timer = Random.Range(minTime, maxTime);
            Debug.Log("Pooling");
        }



    }

    public void MoveToPosition() { 

        if (FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            wasInPos = true;
            ScooterObj.transform.position = Vector3.Lerp(StartPos.position, ChosenPlace.position, (currentLerpTime / lerpTime)*Time.deltaTime);
        }
    }

    public void ReturnToStart()
    {
        if (!FoodTruckState.staticFoodTruckState.isScooterActive && wasInPos)
        {
            if (!hasResettedTime)
            {
                currentLerpTime = 0; hasResettedTime = true;
            }
            ScooterObj.transform.position = Vector3.Lerp(ChosenPlace.position, StartPos.position, currentLerpTime / lerpTime);
            wasInPos = false;
        }
    }
}
