using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMoney : MonoBehaviour
{

    public TMP_Text StandardMoneyText;
    public TMP_Text PreniumMoneyText;

    private void Start()
    {
        MoneyManager.StandardMoney = PlayerPrefs.GetInt("StandardMoney");
        MoneyManager.PreniumMoney = PlayerPrefs.GetInt("PreniumMoney");
    }


    void Update()
    {
        StandardMoneyText.text = "" + MoneyManager.StandardMoney;
        PreniumMoneyText.text = "" + MoneyManager.PreniumMoney;
    }
}
