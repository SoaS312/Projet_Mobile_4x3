using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystemValues : MonoBehaviour
{
    public static GameObject UpgradeSystemValuesHolder;

    [Header("Cook")]
    public List<int> CookLevels;
    public List<int> MaxCookingProgressList;
    public List<int> UsedFoodByClickList;

    public void Awake()
    {
        DontDelete();

        for (int i = 0; i < CookLevels.Count; i++)
        {
            CookLevels.Add(i);
        }
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
}
