using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class AreaCheck : MonoBehaviour
{
    public List<LevelValuesScriptable> Levels;

    public string NameOfArea;

    public bool AreaCompleted;

    public int ActualStars;
    public int MaxStars;

    public void Awake()
    {
        MaxStars = Levels.Count * 3;
    }

    public void Update()
    {
        AreaCompleteCheck();
    }

    public void AreaCompleteCheck()
    {
        for (int i = 0; i < Levels.Count; i++)
        {

            bool CheckCompletion()
            {
                if (Levels[i].unlockedStars == 0)
                {
                    return false;

                }
                else
                {
                    return true;
                }
            }

            if(CheckCompletion() == true)
            {
                AreaCompleted = true;
                PlayerPrefs.SetInt(NameOfArea, 1);

            }
            else
            {
                AreaCompleted = false;
            }
        }
    }

    [Button]
    private void ClearProgression()
    {
        if (PlayerPrefs.HasKey(NameOfArea))
        {
            PlayerPrefs.DeleteKey(NameOfArea);
        }
    }
}
