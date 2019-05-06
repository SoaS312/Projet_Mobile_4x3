using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyLevel : MonoBehaviour
{

    [Header("Driver")]
    public CrewUpgradeScriptable DriverCrew;
    public List<int> DriverCost;
    public TMP_Text DriverCostText;

    [Header("Cook")]
    public CrewUpgradeScriptable CookCrew;
    public List<int> CookCost;
    public TMP_Text CookCostText;

    public void OnEnable()
    {
        DriverCrew.CrewLevelIndex = PlayerPrefs.GetInt("DriverLevel");
        CookCrew.CrewLevelIndex = PlayerPrefs.GetInt("CookLevel");
    }

    public void Update()
    {
        DriverCostText.text = "" + DriverCost[DriverCrew.CrewLevelIndex];
        CookCostText.text = "" + CookCost[CookCrew.CrewLevelIndex];
    }

    public void BuyStandardDriver()
    {
        DriverCrew.CrewLevelIndex = PlayerPrefs.GetInt("DriverLevel");
        if (MoneyManager.StandardMoney >= DriverCost[DriverCrew.CrewLevelIndex]) {
            MoneyManager.StandardMoney -= DriverCost[DriverCrew.CrewLevelIndex];
            DriverCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("DriverLevel", DriverCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
        }
    }

    public void BuyStandardCook()
    {
        CookCrew.CrewLevelIndex = PlayerPrefs.GetInt("CookLevel");
        if (MoneyManager.StandardMoney >= CookCost[CookCrew.CrewLevelIndex])
        {
            MoneyManager.StandardMoney -= CookCost[CookCrew.CrewLevelIndex];
            CookCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("CookLevel", CookCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
        }
    }
}
