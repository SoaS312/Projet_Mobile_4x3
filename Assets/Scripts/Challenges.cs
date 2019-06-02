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
    public string ChallengeName;

    public float BurgerLimit;
    public float MoneyLimit;
    public float FanKickedLimit;
    public float FanSatisfiedLimit;
    public float StarsEarnedLimit;

    public bool ChallengeCompleted;
    public Challenges PreviousChallengeToComplete;

}
