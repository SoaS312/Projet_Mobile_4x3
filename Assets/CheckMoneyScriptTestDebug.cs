using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CheckMoneyScriptTestDebug : MonoBehaviour
{
    public int debugmoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
