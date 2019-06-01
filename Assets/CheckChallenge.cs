using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckChallenge : MonoBehaviour
{
    public TMP_Text Description;
    public Challenges AssociatedChallenge;
    public bool ReadyToBeClaimed;

    private void OnEnable()
    {
        Description.text = "Description :" + AssociatedChallenge.ChallengeText;
    }

    void Accomplish()
    {
        if (ReadyToBeClaimed)
        {
            AssociatedChallenge.ChallengeCompleted = true;
        }
    }
}
