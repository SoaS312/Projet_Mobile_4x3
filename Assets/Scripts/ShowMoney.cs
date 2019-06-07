using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMoney : MonoBehaviour
{

    public TMP_Text StandardMoneyText;
    public TMP_Text PreniumMoneyText;


    void Update()
    {
        MoneyManager.StandardMoney = PlayerPrefs.GetInt("StandardMoney");
        MoneyManager.PreniumMoney = PlayerPrefs.GetInt("PreniumMoney");

        StandardMoneyText.text = "" + MoneyManager.StandardMoney;
        PreniumMoneyText.text = "" + MoneyManager.PreniumMoney;
    }
}
