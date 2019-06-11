using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour
{
    public static Cook staticCook;
    public GameObject FoodTruck;
    public int cookingProgress;
    public int maxCookingProgress;
    public int readyFood;
    public FoodStock foodStockManager;
    public int usedFoodByClick;
    public float actualTimer;
    public float MaxTimer = 0.5f;
    public Image foodProgress;
    public bool hasSwipeToLeft = false;
    public bool hasSwipeToRight = false;

    public CrewUpgradeScriptable CookLevel;

    public AudioClip Cooking1;
    public AudioClip Cooking2;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        maxCookingProgress = CookLevel.CrewUpgradeList[CookLevel.CrewLevelIndex];
        readyFood = 0;
        LevelValues_HolderStatic.SelledBurger_Holded = 0;
        staticCook = this;
        cookingProgress = 0;
    }

    void Update()
    {
        if (cookingProgress == maxCookingProgress)
        {
            cookingProgress = 0;
            readyFood += 1;
            SpawnGameFeelIcons.staticSpawnGameFeelIcons.Spawn();
            LevelValues_HolderStatic.SelledBurger_Holded += 1;
        }

        foodProgress.fillAmount = (float)cookingProgress / (float)maxCookingProgress;

        if (actualTimer > 0)
        {
            actualTimer -= 1 * Time.deltaTime;
        }

        Cooking();
    }

    private void Cooking()
    {

        if (FoodTruckState.staticFoodTruckState.isCookActive)
        {
            if (SwipeLogger.staticSwipeLogger.stockedDirection == "Left" && foodStockManager.food > 0 && actualTimer <= 0 && !hasSwipeToLeft)
            {
                if (!PlayerPrefs.HasKey("Sound"))
                    source.PlayOneShot(Cooking1, 1);
                hasSwipeToLeft = true;
                hasSwipeToRight = false;
                cookingProgress += 1;
                foodStockManager.food -= usedFoodByClick;
                actualTimer = MaxTimer;
            }
            if (SwipeLogger.staticSwipeLogger.stockedDirection == "Right" && foodStockManager.food > 0 && actualTimer <= 0 && !hasSwipeToRight)
            {
                if (!PlayerPrefs.HasKey("Sound"))
                    source.PlayOneShot(Cooking2, 1);
                hasSwipeToRight = true;
                hasSwipeToLeft = false;
                cookingProgress += 1;
                foodStockManager.food -= usedFoodByClick;
                actualTimer = MaxTimer;
            }
        }
    }
}
