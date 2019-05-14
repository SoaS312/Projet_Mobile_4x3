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
    public TMP_Text DriverLevel;

    [Header("Cook")]
    public CrewUpgradeScriptable CookCrew;
    public List<int> CookCost;
    public TMP_Text CookCostText;

    [Header("Vigile")]
    public CrewUpgradeScriptable VigileCrew;
    public List<int> VigileCost;
    public TMP_Text VigileCostText;

    [Header("Seller")]
    public CrewUpgradeScriptable SellerCrew;
    public List<int> SellerCost;
    public TMP_Text SellerCostText;

    [Header("Helico")]
    public CrewUpgradeScriptable HelicoCrew;
    public List<int> HelicoCost;
    public TMP_Text HelicoCostText;

    [Header("Scooter")]
    public CrewUpgradeScriptable ScooterCrew;
    public List<int> ScooterCost;
    public TMP_Text ScooterCostText;

    public void OnEnable()
    {
        DriverCrew.CrewLevelIndex = PlayerPrefs.GetInt("DriverLevel");
        CookCrew.CrewLevelIndex = PlayerPrefs.GetInt("CookLevel");
        VigileCrew.CrewLevelIndex = PlayerPrefs.GetInt("VigileLevel");
        SellerCrew.CrewLevelIndex = PlayerPrefs.GetInt("SellerLevel");
        HelicoCrew.CrewLevelIndex = PlayerPrefs.GetInt("HelicoLevel");
        ScooterCrew.CrewLevelIndex = PlayerPrefs.GetInt("ScooterLevel");
        DriverLevel.text = "Level " + DriverCrew.CrewLevelIndex +":";
    }

    public void Update()
    {
        DriverCostText.text = "" + DriverCost[DriverCrew.CrewLevelIndex];
        CookCostText.text = "" + CookCost[CookCrew.CrewLevelIndex];

        VigileCostText.text = "" + VigileCost[VigileCrew.CrewLevelIndex];
        SellerCostText.text = "" + SellerCost[SellerCrew.CrewLevelIndex];

        HelicoCostText.text = "" + HelicoCost[HelicoCrew.CrewLevelIndex];
        ScooterCostText.text = "" + ScooterCost[ScooterCrew.CrewLevelIndex];
    }

    public void BuyStandardDriver()
    {
        DriverCrew.CrewLevelIndex = PlayerPrefs.GetInt("DriverLevel");
        if (MoneyManager.StandardMoney >= DriverCost[DriverCrew.CrewLevelIndex]) {
            MoneyManager.StandardMoney -= DriverCost[DriverCrew.CrewLevelIndex];
            DriverCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("DriverLevel", DriverCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
            DriverLevel.text = "Level " + DriverCrew.CrewLevelIndex + ":";
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

    public void BuyStandardVigile()
    {
        VigileCrew.CrewLevelIndex = PlayerPrefs.GetInt("VigileLevel");
        if (MoneyManager.StandardMoney >= VigileCost[VigileCrew.CrewLevelIndex])
        {
            MoneyManager.StandardMoney -= VigileCost[VigileCrew.CrewLevelIndex];
            VigileCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("VigileLevel", VigileCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
        }
    }

    public void BuyStandardSeller()
    {
        SellerCrew.CrewLevelIndex = PlayerPrefs.GetInt("SellerLevel");
        if (MoneyManager.StandardMoney >= SellerCost[SellerCrew.CrewLevelIndex])
        {
            MoneyManager.StandardMoney -= SellerCost[SellerCrew.CrewLevelIndex];
            SellerCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("SellerLevel", SellerCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
        }
    }

    public void BuyStandardHelico()
    {
        HelicoCrew.CrewLevelIndex = PlayerPrefs.GetInt("HelicoLevel");
        if (MoneyManager.StandardMoney >= HelicoCost[HelicoCrew.CrewLevelIndex])
        {
            MoneyManager.StandardMoney -= HelicoCost[HelicoCrew.CrewLevelIndex];
            HelicoCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("HelicoLevel", HelicoCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
        }
    }


    public void BuyStandardScooter()
    {
        ScooterCrew.CrewLevelIndex = PlayerPrefs.GetInt("ScooterLevel");
        if (MoneyManager.StandardMoney >= ScooterCost[ScooterCrew.CrewLevelIndex])
        {
            MoneyManager.StandardMoney -= ScooterCost[ScooterCrew.CrewLevelIndex];
            ScooterCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("ScooterLevel", ScooterCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("StandardMoney", MoneyManager.StandardMoney);
        }
    }
}
