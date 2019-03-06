using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigileUpgrade : MonoBehaviour
{
    public List<int> AttackValue;
    public int lastBoughtUpgrade = 0;
    public int actualUpgradeValue = 0;
    public int originalDamage;
    public int MaxDamage;
    public static VigileUpgrade staticVigileUpgrade;

    private void Awake()
    {
        staticVigileUpgrade = this;
        ApplyUpgrade();
    }

    private void ApplyUpgrade()
    {
        for (int i = 0; i < MaxDamage; i++)
        {
            AttackValue.Add(i);
        }
        actualUpgradeValue = originalDamage + AttackValue[lastBoughtUpgrade];
    }
}
