using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class LevelValues : MonoBehaviour
{
    public int Timer;


    [Header("Obstacles Settings")]
    public float minTime_Obstacle;
    public float maxTime_Obstacle;

    [Header("Fuel Settings")]
    public float decayTime_Fuel;

    [Button]
    public void SendValues()
    {
        LevelValues_HolderStatic.minTime_Holded = minTime_Obstacle;
        LevelValues_HolderStatic.maxTime_Holded = maxTime_Obstacle;
        LevelValues_HolderStatic.decayTime_Holded = decayTime_Fuel;
    }
}

