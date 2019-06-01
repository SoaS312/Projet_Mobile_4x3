using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "New Challenge", menuName = "Challenges/New Challenge")]
public class Challenges : ScriptableObject
{
    [Dropdown("ChallengeTypes")]
    public string ChallengeType;

    private string[] ChallengeTypes = new string[] { "3Stars", "AreaComplete", "BurgerSelled", "MoneyEarned", "FanKicked", "FanSatisfied", "StarsEarned" };

    [ResizableTextArea]
    public string ChallengeText;

    public LevelValuesScriptable LevelToCheck;
    // public AreaStarsCheck AreaToCheck; Need to creat AreaStarsCheck
    public int BurgerLimit;
    public int MoneyLimit;
    public int FanKickedLimit;
    public int FanSatisfiedLimit;
    public int StarsEarnedLimit;

    public bool ChallengeCompleted;
    public Challenges PreviousChallengeToComplete;

}
