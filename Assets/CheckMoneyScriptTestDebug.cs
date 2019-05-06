using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CheckMoneyScriptTestDebug : MonoBehaviour
{
    public int debugmoney;
    void Update()
    {
        debugmoney = MoneyManager.StandardMoney;
    }

    [Button]
    public void GiveStandardMOney()
    {
        MoneyManager.StandardMoney += 100;
    }
}
