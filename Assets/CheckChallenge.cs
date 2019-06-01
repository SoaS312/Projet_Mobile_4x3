using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckChallenge : MonoBehaviour
{
    public TMP_Text Description;
    public Challenges AssociatedChallenge;
    public bool ReadyToBeClaimed;
    // public gameObject Shining;
    public GameObject AssociatedArea;

    private void OnEnable()
    {
        Description.text = "Description :" + AssociatedChallenge.ChallengeText;
    }

    void Update()
    {
        BurgerObjectif();
        MoneyObjectif();
        FanKickedObjectif();
        FanSatisfiedObjectif();
        ThreeStarsObjectif();
        AreaCompleteObjectif();
    }

    private void AreaCompleteObjectif()
    {/*
        if (AssociatedChallenge.ChallengeType == "AreaComplete")
        {
            if (AssociatedArea.complete  && !ReadyToBeClaimed)
            {
            ReadyToBeClaimed = true;
            }
        }*/
    }

    private void ThreeStarsObjectif()
    {
        /*if (AssociatedChallenge.ChallengeType == "3Stars")
        {
            if (AssociatedArea.TotalStars == AssociatedArea.MaxStars  && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }*/
    }

    private void StarsEarnedObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "StarsEarned")
        {
            if(PlayerPrefs.GetInt("TotalStarsEarned") >= AssociatedChallenge.StarsEarnedLimit && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    private void FanKickedObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "FanKicked")
        {
            if (PlayerPrefs.GetInt("TotalFanKicked") >= AssociatedChallenge.FanKickedLimit && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    private void FanSatisfiedObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "FanSatisfied")
        {
            if (PlayerPrefs.GetInt("TotalFanSatisfied") >= AssociatedChallenge.FanSatisfiedLimit && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    private void MoneyObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "MoneyEarned")
        {
            if (PlayerPrefs.GetInt("TotalMoneyEarned") >= AssociatedChallenge.MoneyLimit && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    private void BurgerObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "BurgerSelled")
        {
            if (PlayerPrefs.GetInt("TotalSelledBurger") >= AssociatedChallenge.BurgerLimit && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    void Accomplish()
    {
        if (ReadyToBeClaimed && !AssociatedChallenge.ChallengeCompleted)
        {
            AssociatedChallenge.ChallengeCompleted = true;
        }
    }
}
