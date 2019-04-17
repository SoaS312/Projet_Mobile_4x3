using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject LoseScreen;
    public GameObject UIGame;
    public GameObject SpawnManager;
    public bool Win = false;
    public bool Loose = false;

    private float myDeltaTime;
    private bool speedDown = false;
    private float minTimeScale = 0.0f;
    private float decreaseSpeed = 0.075f;


    [Header("Timer")]
    public float maxTime;
    public float currentTime;

    [Header("UI")]
    public TextMeshProUGUI LevelNameText;
    public TextMeshProUGUI FirstStarText;
    public TextMeshProUGUI SecondStarText;
    public TextMeshProUGUI ThirdStarText;

    [Header("Stars")]
    public bool StarOne;
    public GameObject StarOneUI;
    public bool StarTwo;
    public GameObject StarTwoUI;
    public bool StarThree;
    public GameObject StarThreeUI;

    [Header("Objectives")]
    public List<int> Objective_number;


    void Awake()
    {
        myDeltaTime = Time.deltaTime;
        LevelNameText.text = "" + LevelValues_HolderStatic.LevelName_Holder;
        Objective_number = LevelValues_HolderStatic.ObjectiveKeys;
        maxTime = LevelValues_HolderStatic.maxMissionTime_holder;
        currentTime = maxTime;
        Win = false;
        SetObjectivesNumber();
    }

    private void SetObjectivesNumber()
    {
        if (LevelValues_HolderStatic.WhichObjective == "Burger")
        {
            FirstStarText.text = "Cook " + LevelValues_HolderStatic.ObjectiveKeys[0] + " lunches";
            SecondStarText.text = "Cook " + LevelValues_HolderStatic.ObjectiveKeys[1] + " lunches";
            ThirdStarText.text = "Cook " + LevelValues_HolderStatic.ObjectiveKeys[2] + " lunches";
        }

        if (LevelValues_HolderStatic.WhichObjective == "Money")
        {
            FirstStarText.text = "Reach " + LevelValues_HolderStatic.ObjectiveKeys[0] + " money";
            SecondStarText.text = "Reach " + LevelValues_HolderStatic.ObjectiveKeys[1] + " money";
            ThirdStarText.text = "Reach " + LevelValues_HolderStatic.ObjectiveKeys[2] + " money";
        }
    }

    public void Update()
    {
        LooseState();

        LevelValues_HolderStatic.Win = Win;

        CheckStarsStatus();

        TimeDecrease();
    }

    private void TimeDecrease()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        if (currentTime < 0)
        {
            currentTime = 0;
        }
    }

    private void CheckStarsStatus()
    {
        LevelValues_HolderStatic.StarOne = StarOne;
        if (StarOne)
            StarOneUI.SetActive(true);
        LevelValues_HolderStatic.StarTwo = StarTwo;
        if (StarTwo)
            StarTwoUI.SetActive(true);
        LevelValues_HolderStatic.StarThree = StarThree;
        if (StarThree)
            StarThreeUI.SetActive(true);

        if (LevelValues_HolderStatic.WhichObjective == "Burger")
        {
            if (LevelValues_HolderStatic.SelledBurger_Holded > LevelValues_HolderStatic.ObjectiveKeys[0])
            {
                StarOne = true;
            }
            if (LevelValues_HolderStatic.SelledBurger_Holded > LevelValues_HolderStatic.ObjectiveKeys[1])
            {
                StarTwo = true;
            }
            if (LevelValues_HolderStatic.SelledBurger_Holded > LevelValues_HolderStatic.ObjectiveKeys[2])
            {
                StarThree = true;
            }
        }

        if (LevelValues_HolderStatic.WhichObjective == "Money")
        {
            if (LevelValues_HolderStatic.earnedMoney_Holded > LevelValues_HolderStatic.ObjectiveKeys[0])
            {
                StarOne = true;
            }
            if (LevelValues_HolderStatic.earnedMoney_Holded > LevelValues_HolderStatic.ObjectiveKeys[1])
            {
                StarTwo = true;
            }
            if (LevelValues_HolderStatic.earnedMoney_Holded > LevelValues_HolderStatic.ObjectiveKeys[2])
            {
                StarThree = true;
            }
        }
    }

    private void WinState()
    {
        if (currentTime <= 0)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, minTimeScale, myDeltaTime * decreaseSpeed);
            if (Time.timeScale <= 0)
            {
                Win = true;
                //WinScreen.SetActive(true);
                LoseScreen.SetActive(false);
                UIGame.SetActive(false);
                SpawnManager.SetActive(false);
            }
        }
    }

private void LooseState()
    {
        if (GameManager.GetComponent<FuelStock>().fuel <= 0)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, minTimeScale, myDeltaTime * decreaseSpeed);
            if (Time.timeScale <= 0)
            {
                Loose = true;
                LoseScreen.SetActive(true);
                UIGame.SetActive(false);
                SpawnManager.SetActive(false);
            }
        }
    }
}
