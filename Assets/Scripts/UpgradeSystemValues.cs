using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class UpgradeSystemValues : MonoBehaviour
{
    public static GameObject UpgradeSystemValuesHolder;

    public static UpgradeSystemValues staticUpgradeSystem;

    // Dans le code du controlleur correspondant =>   valeur == upgradesystemvalues.jobUpgradeList[index];

    [Header("Driver")]
    public static int DriverLevelIndex;
    public int DriverLevelIndexLOOK; // A dégager quand l'upgrade fonctionnera bien
    public List<int> DriverUpgradeList; // max fuel

    [Header("Cook")]
    public static int CookLevelIndex;
    public int CookLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> CookUpgradeList; // max ready food

    [Header("Seller")]
    public static int SellerLevelIndex;
    public int SellerLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> SellerUpgradeList; // Money earned

    [Header("Vigile")]
    public static int VigileLevelIndex;
    public int VigileLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> VigileUpgradeList; // Attack value

    [Header("Helico")]
    public static int HelicoLevelIndex;
    public int HelicoLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> HelicoUpgradeList; // Fuel given

    [Header("Scooter")]
    public static int ScooterLevelIndex;
    public int ScooterLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> ScooterUpgradeList; // Food given

    public void Awake()
    {
        DontDelete();
    }

    public void Update()
    {
        DriverLevelIndexLOOK = DriverLevelIndex;
    }

    private void DontDelete()
    {
        if (UpgradeSystemValuesHolder == null)
        {
            UpgradeSystemValuesHolder = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (UpgradeSystemValuesHolder != this)
        {
            Destroy(gameObject);
        }
    }


    [Button]
    private void ResetIndex()
    {
        DriverLevelIndex = 0;
        CookLevelIndex = 0;
        SellerLevelIndex = 0;
        VigileLevelIndex = 0;
        HelicoLevelIndex = 0;
        ScooterLevelIndex = 0;
    }







}
