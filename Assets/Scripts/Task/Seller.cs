using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public GameObject FoodTruck;
    public int MoneyEarn;
    public Cook cook;
    public bool SellerSelected;
    public static Seller staticSeller;

    public CrewUpgradeScriptable SellerLevel;


    private void Start()
    {
        MoneyEarn = SellerLevel.CrewUpgradeList[SellerLevel.CrewLevelIndex];
    }

    void Update()
    {
        staticSeller = this;
        cook = this.gameObject.GetComponent<Cook>();

    }
}
