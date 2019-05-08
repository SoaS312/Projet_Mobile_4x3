using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevelUpgrades : MonoBehaviour
{
    public void Resetting()
    {
        Debug.Log("Reseted");
        PlayerPrefs.SetInt("DriverLevel", 0);
        PlayerPrefs.SetInt("CookLevel", 0);
        PlayerPrefs.SetInt("SellerLevel", 0);
        PlayerPrefs.SetInt("VigileLevel", 0);
        PlayerPrefs.SetInt("HelicoLevel", 0);
        PlayerPrefs.SetInt("ScooterLevel", 0);
        Debug.Log(PlayerPrefs.GetInt("DriverLevel"));
    }
}
