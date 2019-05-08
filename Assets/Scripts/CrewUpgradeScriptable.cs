using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCrewUpgrade", menuName = "CrewUpgrade/NewCrewUpgrade")]
public class CrewUpgradeScriptable : ScriptableObject
{
    public int CrewLevelIndex;
    public List<int> CrewUpgradeList;

    public void SetLevel()
    {

    }
}
