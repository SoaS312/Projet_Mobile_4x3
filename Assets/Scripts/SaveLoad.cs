using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SaveLoad : MonoBehaviour
{    //Ce scipt need Execution order before everything (except ValuesHolder)
    public static SaveLoad staticSaveLoad;

    public List<LevelValuesScriptable> Level;

    public void Start()
    {
        staticSaveLoad = this;
        DontDestroyOnLoad(gameObject);
    }

    [Button]
    public void SavingStars()
    {

        //Level1
        PlayerPrefs.SetInt("unlockedStarsLevel01", Level[0].unlockedStars);/*
        //Level2
        PlayerPrefs.SetInt("unlockedStarsLevel02", Level[1].unlockedStars);
        //Level3
        PlayerPrefs.SetInt("unlockedStarsLevel03", Level[2].unlockedStars);*/
    }

    [Button]
    public void LoadingStars()
    {
        if (PlayerPrefs.HasKey("unlockedStarsLevel01"))
            Level[0].unlockedStars = PlayerPrefs.GetInt("unlockedStarsLevel01", 0);

        /*if (PlayerPrefs.HasKey("unlockedStarsLevel02"))
            Level[1].unlockedStars = PlayerPrefs.GetInt("unlockedStarsLevel02", 0);

        if (PlayerPrefs.HasKey("unlockedStarsLevel03"))
            Level[2].unlockedStars = PlayerPrefs.GetInt("unlockedStarsLevel03", 0);*/
    }
}