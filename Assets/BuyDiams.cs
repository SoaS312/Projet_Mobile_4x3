using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyDiams : MonoBehaviour
{
    public int DiamsQuantity;

    public void BuySmallDiams()
    {
        DiamsQuantity = 10;
        PlayerPrefs.SetInt("PreniumMoney", PlayerPrefs.GetInt("PreniumMoney") + DiamsQuantity);
    }

    public void BuyMedDiams()
    {
        DiamsQuantity = 25;
        PlayerPrefs.SetInt("PreniumMoney", PlayerPrefs.GetInt("PreniumMoney") + DiamsQuantity);
    }

    public void BuyHeavyDiams()
    {
        DiamsQuantity = 50;
        PlayerPrefs.SetInt("PreniumMoney", PlayerPrefs.GetInt("PreniumMoney") + DiamsQuantity);
    }
}
