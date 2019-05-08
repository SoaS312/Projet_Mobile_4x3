using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowMoney : MonoBehaviour
{

    public TMP_Text StandardMoneyText;

    private void Start()
    {
        MoneyManager.StandardMoney = PlayerPrefs.GetInt("StandardMoney");
    }


    void Update()
    {
        StandardMoneyText.text = "" + MoneyManager.StandardMoney;
    }
}
