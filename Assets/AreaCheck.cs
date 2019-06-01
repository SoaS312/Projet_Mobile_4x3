using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    public List<LevelValuesScriptable> Levels;

    public void Start()
    {
        foreach (LevelValuesScriptable child in transform)
            Levels.Add(child);
    }
}
