using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class UpgradeSystemValues : MonoBehaviour
{
    public static GameObject UpgradeSystemValuesHolder;

    // Dans le code du controlleur correspondant =>   valeur == upgradesystemvalues.jobUpgradeList[index];

    [Header("Driver")]
    public static int DriverLevelIndex;
    public int DriverLevelIndexLOOK; // A dégager quand l'upgrade fonctionnera bien
    public List<int> DriverUpgradeList; // ça change

    [Header("Cook")]
    public static int CookLevelIndex;
    public int CookLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> CookUpgradeList; //

    [Header("Seller")]
    public static int SellerLevelIndex;
    public int SellerLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> SellerUpgradeList; //

    [Header("Vigile")]
    public static int VigileLevelIndex;
    public int VigileLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> VigileUpgradeList; //

    [Header("Helico")]
    public static int HelicoLevelIndex;
    public int HelicoLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> HelicoUpgradeList; //

    [Header("Scooter")]
    public static int ScooterLevelIndex;
    public int ScooterLevelIndexLOOK;// A dégager quand l'upgrade fonctionnera bien
    public List<int> ScooterUpgradeList; //

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
private void UpgradeDriver()
    {
        if (DriverLevelIndex < 100)
        DriverLevelIndex += 1;
    }

    [Button]
    private void ResetDriver()
    {
        DriverLevelIndex = 0;
    }







}
