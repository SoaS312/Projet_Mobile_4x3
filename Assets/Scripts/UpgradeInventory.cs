using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeInventory : MonoBehaviour
{
    public static UpgradeInventory staticUpgradeInventory;
    public int commonDriverCard;
    public  int commonCookCard;
    public int commonSellerCard;
    public int commonVigileCard;
    public int commonCoursierCard;
    public int commonHelicoCard;

    public void Awake()
    {
        staticUpgradeInventory = this;
    }
}
