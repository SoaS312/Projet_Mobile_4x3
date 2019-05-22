using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewMainTitleScriptable", menuName = "MainTitle/NewMainTitleScriptable")]
public class MainTitleCheck : ScriptableObject
{
    public bool MainMenuSkipped = false;

    void Start()
    {
        MainMenuSkipped = false;
    }

}
