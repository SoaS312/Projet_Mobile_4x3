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
    public Shake DriverStandardButtonShake;
    public Shake DriverPreniumButtonShake;

    [Header("Driver Prenium")]
    public List<int> DriverCostPrenium;
    public TMP_Text DriverCostPreniumText;

    [Header("Driver Level")]
    public TMP_Text DriverLevel;

    [Header("Cook")]
    public CrewUpgradeScriptable CookCrew;
    public List<int> CookCost;
    public TMP_Text CookCostText;
    public Shake CookStandardButtonShake;
    //public Shake DriverPreniumButtonShake;

    [Header("Cook Prenium")]
    public List<int> CookCostPrenium;
    public TMP_Text CookCostPreniumText;

    [Header("Cook Level")]
    public TMP_Text CookLevel;

    [Header("Vigile")]
    public CrewUpgradeScriptable VigileCrew;
    public List<int> VigileCost;
    public TMP_Text VigileCostText;

    [Header("Vigile Prenium")]
    public List<int> VigileCostPrenium;
    public TMP_Text VigileCostPreniumText;

    [Header("Vigile Level")]
    public TMP_Text VigileLevel;

    [Header("Seller")]
    public CrewUpgradeScriptable SellerCrew;
    public List<int> SellerCost;
    public TMP_Text SellerCostText;

    [Header("Seller Prenium")]
    public List<int> SellerCostPrenium;
    public TMP_Text SellerCostPreniumText;

    [Header("Seller Level")]
    public TMP_Text SellerLevel;

    [Header("Helico")]
    public CrewUpgradeScriptable HelicoCrew;
    public List<int> HelicoCost;
    public TMP_Text HelicoCostText;

    [Header("Helico Prenium")]
    public List<int> HelicoCostPrenium;
    public TMP_Text HelicoCostPreniumText;

    [Header("Helico Level")]
    public TMP_Text HelicoLevel;

    [Header("Scooter")]
    public CrewUpgradeScriptable ScooterCrew;
    public List<int> ScooterCost;
    public TMP_Text ScooterCostText;

    [Header("Scooter Prenium")]
    public List<int> ScooterCostPrenium;
    public TMP_Text ScooterCostPreniumText;

    [Header("Scooter Level")]
    public TMP_Text ScooterLevel;

    public void OnEnable()
    {
        DriverCrew.CrewLevelIndex = PlayerPrefs.GetInt("DriverLevel");
        CookCrew.CrewLevelIndex = PlayerPrefs.GetInt("CookLevel");
        VigileCrew.CrewLevelIndex = PlayerPrefs.GetInt("VigileLevel");
        SellerCrew.CrewLevelIndex = PlayerPrefs.GetInt("SellerLevel");
        HelicoCrew.CrewLevelIndex = PlayerPrefs.GetInt("HelicoLevel");
        ScooterCrew.CrewLevelIndex = PlayerPrefs.GetInt("ScooterLevel");
        DriverLevel.text = "Level " + DriverCrew.CrewLevelIndex +":";
        CookLevel.text = "Level " + CookCrew.CrewLevelIndex + ":";
        SellerLevel.text = "Level " + SellerCrew.CrewLevelIndex + ":";
        VigileLevel.text = "Level " + VigileCrew.CrewLevelIndex + ":";
        HelicoLevel.text = "Level " + HelicoCrew.CrewLevelIndex + ":";
        ScooterLevel.text = "Level " + ScooterCrew.CrewLevelIndex + ":";
    }

    public void Update()
    {
        DriverCostText.text = "" + DriverCost[DriverCrew.CrewLevelIndex];
        DriverCostPreniumText.text = "" + DriverCostPrenium[DriverCrew.CrewLevelIndex];

        CookCostText.text = "" + CookCost[CookCrew.CrewLevelIndex];
        CookCostPreniumText.text = "" + CookCostPrenium[CookCrew.CrewLevelIndex];

        VigileCostText.text = "" + VigileCost[VigileCrew.CrewLevelIndex];
        VigileCostPreniumText.text = "" + VigileCostPrenium[VigileCrew.CrewLevelIndex];

        SellerCostText.text = "" + SellerCost[SellerCrew.CrewLevelIndex];
        SellerCostPreniumText.text = "" + SellerCostPrenium[SellerCrew.CrewLevelIndex];

        HelicoCostText.text = "" + HelicoCost[HelicoCrew.CrewLevelIndex];
        HelicoCostPreniumText.text = "" + HelicoCostPrenium[HelicoCrew.CrewLevelIndex];

        ScooterCostText.text = "" + ScooterCost[ScooterCrew.CrewLevelIndex];
        ScooterCostPreniumText.text = "" + ScooterCostPrenium[ScooterCrew.CrewLevelIndex];
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
        else
        {
            DriverStandardButtonShake.Shaking(5f);
            if (!PlayerPrefs.HasKey("Vibrations"))
                Handheld.Vibrate();
        }
    }

    public void BuyPreniumDriver()
    {
        DriverCrew.CrewLevelIndex = PlayerPrefs.GetInt("DriverLevel");
        if (MoneyManager.PreniumMoney >= DriverCostPrenium[DriverCrew.CrewLevelIndex])
        {
            MoneyManager.PreniumMoney -= DriverCostPrenium[DriverCrew.CrewLevelIndex];
            DriverCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("DriverLevel", DriverCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("PreniumMoney", MoneyManager.PreniumMoney);
            DriverLevel.text = "Level " + DriverCrew.CrewLevelIndex + ":";
        }
        else
        {
            DriverPreniumButtonShake.Shaking(5f);
            if (!PlayerPrefs.HasKey("Vibrations"))
                Handheld.Vibrate();
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
            CookLevel.text = "Level " + CookCrew.CrewLevelIndex + ":";
        }
        else
        {
            if (!PlayerPrefs.HasKey("Vibrations"))
                Handheld.Vibrate();
        }
    }

    public void BuyPreniumCook()
    {
        CookCrew.CrewLevelIndex = PlayerPrefs.GetInt("CookLevel");
        if (MoneyManager.PreniumMoney >= CookCostPrenium[CookCrew.CrewLevelIndex])
        {
            MoneyManager.PreniumMoney -= CookCostPrenium[CookCrew.CrewLevelIndex];
            CookCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("CookLevel", CookCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("PreniumMoney", MoneyManager.PreniumMoney);
            CookLevel.text = "Level " + CookCrew.CrewLevelIndex + ":";
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
            VigileLevel.text = "Level " + VigileCrew.CrewLevelIndex + ":";
        }
    }

    public void BuyPreniumVigile()
    {
        VigileCrew.CrewLevelIndex = PlayerPrefs.GetInt("VigileLevel");
        if (MoneyManager.PreniumMoney >= VigileCostPrenium[VigileCrew.CrewLevelIndex])
        {
            MoneyManager.PreniumMoney -= VigileCostPrenium[VigileCrew.CrewLevelIndex];
            VigileCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("VigileLevel", CookCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("PreniumMoney", MoneyManager.PreniumMoney);
            VigileLevel.text = "Level " + VigileCrew.CrewLevelIndex + ":";
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
            SellerLevel.text = "Level " + SellerCrew.CrewLevelIndex + ":";
        }
    }

    public void BuyPreniumSeller()
    {
       SellerCrew.CrewLevelIndex = PlayerPrefs.GetInt("SellerLevel");
        if (MoneyManager.PreniumMoney >= SellerCostPrenium[SellerCrew.CrewLevelIndex])
        {
            MoneyManager.PreniumMoney -= SellerCostPrenium[SellerCrew.CrewLevelIndex];
            SellerCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("SellerLevel", SellerCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("PreniumMoney", MoneyManager.PreniumMoney);
            SellerLevel.text = "Level " + SellerCrew.CrewLevelIndex + ":";
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
            HelicoLevel.text = "Level " + HelicoCrew.CrewLevelIndex + ":";
        }
    }

    public void BuyPreniumHelico()
    {
        HelicoCrew.CrewLevelIndex = PlayerPrefs.GetInt("HelicoLevel");
        if (MoneyManager.PreniumMoney >= HelicoCostPrenium[HelicoCrew.CrewLevelIndex])
        {
            MoneyManager.PreniumMoney -= HelicoCostPrenium[HelicoCrew.CrewLevelIndex];
            HelicoCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("HelicoLevel", HelicoCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("PreniumMoney", MoneyManager.PreniumMoney);
            HelicoLevel.text = "Level " + HelicoCrew.CrewLevelIndex + ":";
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
            ScooterLevel.text = "Level " + ScooterCrew.CrewLevelIndex + ":";
        }
    }

    public void BuyPreniumScooter()
    {
        ScooterCrew.CrewLevelIndex = PlayerPrefs.GetInt("ScooterLevel");
        if (MoneyManager.PreniumMoney >= ScooterCostPrenium[ScooterCrew.CrewLevelIndex])
        {
            MoneyManager.PreniumMoney -= ScooterCostPrenium[ScooterCrew.CrewLevelIndex];
            ScooterCrew.CrewLevelIndex += 1;
            PlayerPrefs.SetInt("ScooterLevel", ScooterCrew.CrewLevelIndex);
            PlayerPrefs.SetInt("PreniumMoney", MoneyManager.PreniumMoney);
            ScooterLevel.text = "Level " + ScooterCrew.CrewLevelIndex + ":";
        }
    }
}
