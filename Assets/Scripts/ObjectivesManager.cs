using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{

    public Transform Routes;
    public float FarAwaySpeed;

    private bool WonMoney = false;

    public GameObject ParticleLikes;
    public ParticleSystem Likes;
    public ParticleSystem Dislikes;
    public static int LikesNumber;
    public static int DislikesNumber;


    public GameObject Foodtruck;

    public GameObject GameManager;
    public GameObject LoseScreen;
    public GameObject UIGame;
    public GameObject SpawnManager;
    public GameObject WinScreen;
    public bool Win = false;
    public bool Loose = false;

    private float myDeltaTime;
    private bool speedDown = false;
    private float minTimeScale = 0.0f;
    public float decreaseSpeed = 0.00275f;


    [Header("Timer")]
    public float maxTime;
    public float currentTime;

    [Header("UI")]
    public TextMeshProUGUI TitleNameText;
    public TextMeshProUGUI LevelNameText;
    public TextMeshProUGUI FirstStarText;
    public TextMeshProUGUI SecondStarText;
    public TextMeshProUGUI ThirdStarText;
    public TextMeshProUGUI MoneyText;
    public GameObject HomeButtonToActive;
    public GameObject[] ButtonsToDesactive;

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
        Foodtruck = GameObject.FindGameObjectWithTag("FoodTruck");

        myDeltaTime = Time.deltaTime;
        LevelNameText.text = "" + LevelValues_HolderStatic.LevelName_Holder;
        Objective_number = LevelValues_HolderStatic.ObjectiveKeys;
        maxTime = LevelValues_HolderStatic.maxMissionTime_holder;
        currentTime = maxTime;
        Win = false;
        SetObjectivesNumber();

        LevelValues_HolderStatic.staticUnlockedStars = 0;
        LevelValues_HolderStatic.StarOne = false;
        LevelValues_HolderStatic.StarTwo = false;
        LevelValues_HolderStatic.StarThree = false;
        LevelValues_HolderStatic.SelledBurger_Holded = 0;
        LevelValues_HolderStatic.earnedMoney_Holded = 0;
        Time.timeScale = 1;

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
        WinState();

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
            if (LevelValues_HolderStatic.SelledBurger_Holded >= LevelValues_HolderStatic.ObjectiveKeys[0])
            {
                if (StarOne == false)
                {
                    LevelValues_HolderStatic.staticUnlockedStars += 1;
                }
                StarOne = true;
}
            if (LevelValues_HolderStatic.SelledBurger_Holded >= LevelValues_HolderStatic.ObjectiveKeys[1])
            {
                if (StarTwo == false)
                {
                    LevelValues_HolderStatic.staticUnlockedStars += 1;
                }
                StarTwo = true;
            }
            if (LevelValues_HolderStatic.SelledBurger_Holded >= LevelValues_HolderStatic.ObjectiveKeys[2])
            {
                if (StarThree == false)
                {
                    LevelValues_HolderStatic.staticUnlockedStars += 1;
                }
                StarThree = true;
            }
        }

        if (LevelValues_HolderStatic.WhichObjective == "Money")
        {
            if (LevelValues_HolderStatic.earnedMoney_Holded >= LevelValues_HolderStatic.ObjectiveKeys[0])
            {
                if (StarOne == false)
                {
                    LevelValues_HolderStatic.staticUnlockedStars += 1;
                }
                StarOne = true;
            }
            if (LevelValues_HolderStatic.earnedMoney_Holded >= LevelValues_HolderStatic.ObjectiveKeys[1])
            {
                if (StarTwo == false)
                {
                    LevelValues_HolderStatic.staticUnlockedStars += 1;
                }
                StarTwo = true;
            }
            if (LevelValues_HolderStatic.earnedMoney_Holded >= LevelValues_HolderStatic.ObjectiveKeys[2])
            {
                if (StarThree == false)
                {
                    LevelValues_HolderStatic.staticUnlockedStars += 1;
                }
                StarThree = true;
            }
        }
    }

    private void WinState()
    {
        if (currentTime <= 0)
        {
            WinMoney();

            Win = true;
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, minTimeScale, decreaseSpeed);
            Routes.position += new Vector3(FarAwaySpeed, 0, 0);
            Foodtruck.GetComponent<BoxCollider>().enabled = false;
            if (Time.timeScale <= 0.1 && Win)
            {
                ParticleLikes.SetActive(true);
            }

            if (Time.timeScale <= 0 && Win)
            {
                ParticleLikes.SetActive(true);
                HomeButtonToActive.SetActive(true);
                foreach (GameObject obj in ButtonsToDesactive)
                {
                    obj.SetActive(false);
                }
                WinScreen.SetActive(true);
                UIGame.SetActive(false);
                SpawnManager.SetActive(false);
                FuelStock.staticFuelStock.decayTime = 0;
            }
        }
    }

    private void WinMoney()
    {
        if (StarOne && !StarTwo && !StarThree && !WonMoney)
        {
            MoneyManager.StandardMoney += ScoreManager.money / 3;
            WonMoney = true;
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
            MoneyText.text = "You earned " + (ScoreManager.money / 3) + " money.";
            PlayerPrefs.SetInt("TotalStarsEarned", PlayerPrefs.GetInt("TotalStarsEarned") + 1);
        }
        else if (StarTwo && StarOne && !StarThree && !WonMoney)
        {
            MoneyManager.StandardMoney += ScoreManager.money / 2;
            WonMoney = true;
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
            MoneyText.text = "You earned " + (ScoreManager.money / 2) + " money.";
            PlayerPrefs.SetInt("TotalStarsEarned", PlayerPrefs.GetInt("TotalStarsEarned") + 2);
        }
        else if (StarThree && StarOne && StarTwo && !WonMoney)
        {
            MoneyManager.StandardMoney += ScoreManager.money;
            WonMoney = true;
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
            MoneyText.text = "You earned " + (ScoreManager.money) + " money.";
            PlayerPrefs.SetInt("TotalStarsEarned", PlayerPrefs.GetInt("TotalStarsEarned") + 3);
        }
    }

    private void LooseState()
    {
        if (GameManager.GetComponent<FuelStock>().fuel <= 0)
        {
            Time.timeScale = Mathf.MoveTowards(Time.timeScale, minTimeScale, decreaseSpeed);
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
