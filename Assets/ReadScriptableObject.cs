using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScriptableObject : MonoBehaviour
{
    public LevelValuesScriptable Level;

    public void Awake()
    {
        Level.Awake();
    }

    public void Start()
    {
        Level.Start();
    }
}
