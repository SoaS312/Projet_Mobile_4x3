using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.UI;

public class CheckChallenge : MonoBehaviour
{
    public TMP_Text ChallengeNameText;
    public TMP_Text Description;
    public Challenges AssociatedChallenge;
    public bool ReadyToBeClaimed;
    // public gameObject Shining;
    public AreaCheck AssociatedArea;
    public bool Complete;
    public Image GaugeFill;
    public TMP_Text GaugePercent;


    private void OnEnable()
    {
        ChallengeNameText.text = AssociatedChallenge.ChallengeName;
        Description.text = AssociatedChallenge.ChallengeText;

        if (PlayerPrefs.HasKey(AssociatedChallenge.ChallengeName)){
            Complete = true;
        }
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
    {


        if (AssociatedChallenge.ChallengeType == "AreaComplete")
        {
            if (AssociatedArea.AreaCompleted  && !ReadyToBeClaimed)
            {
                GaugeFill.fillAmount = 1;
                GaugePercent.text = "1 / 1";
                ReadyToBeClaimed = true;
            }
            else if (!AssociatedArea.AreaCompleted)
            {
                GaugeFill.fillAmount = 0;
                GaugePercent.text = "0 / 1";
                ReadyToBeClaimed = false;
            }
        }
    }

    private void ThreeStarsObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "3Stars")
        {
            GaugeFill.fillAmount = AssociatedArea.ActualStars / AssociatedArea.MaxStars;
            GaugePercent.text = AssociatedArea.ActualStars + " / " + AssociatedArea.MaxStars;

            if (AssociatedArea.ActualStars == AssociatedArea.MaxStars  && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    private void StarsEarnedObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "StarsEarned")
        {
            GaugeFill.fillAmount = PlayerPrefs.GetInt("TotalStarsEarned") / AssociatedChallenge.StarsEarnedLimit;
            GaugePercent.text = PlayerPrefs.GetInt("TotalStarsEarned") + " / " + AssociatedChallenge.StarsEarnedLimit;

            if (PlayerPrefs.GetInt("TotalStarsEarned") >= AssociatedChallenge.StarsEarnedLimit && !ReadyToBeClaimed)
            {
                ReadyToBeClaimed = true;
            }
        }
    }

    private void FanKickedObjectif()
    {
        if (AssociatedChallenge.ChallengeType == "FanKicked")
        {
            GaugeFill.fillAmount = PlayerPrefs.GetInt("TotalFanKicked") / AssociatedChallenge.FanKickedLimit;
            GaugePercent.text = PlayerPrefs.GetInt("TotalFanKicked") + " / " + AssociatedChallenge.FanKickedLimit;

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
            GaugeFill.fillAmount = PlayerPrefs.GetInt("TotalFanSatisfied") / AssociatedChallenge.FanSatisfiedLimit;
            GaugePercent.text = PlayerPrefs.GetInt("TotalFanSatisfied") + " / " + AssociatedChallenge.FanSatisfiedLimit;

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
            GaugeFill.fillAmount = PlayerPrefs.GetInt("TotalMoneyEarned") / AssociatedChallenge.MoneyLimit;
            GaugePercent.text = PlayerPrefs.GetInt("TotalMoneyEarned") + " / " + AssociatedChallenge.MoneyLimit;

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
            GaugeFill.fillAmount = (float)(PlayerPrefs.GetInt("TotalSelledBurger") / AssociatedChallenge.BurgerLimit);
            GaugePercent.text = PlayerPrefs.GetInt("TotalSelledBurger") + " / " + AssociatedChallenge.BurgerLimit;

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
            Complete = true;
            AssociatedChallenge.ChallengeCompleted = true;
            PlayerPrefs.SetInt(AssociatedChallenge.ChallengeName, 1);
        }
    }
}
