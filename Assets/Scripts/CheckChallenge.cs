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
    public AreaCheck AssociatedArea;
    public bool Complete;
    public Image GaugeFill;
    public TMP_Text GaugePercent;
    public List<Challenges> NextChallenges;
    public int NextIndex;
    public GameObject Reward;

    public Image Logo;
    public Image Fond;

    public GameObject ChallengeNotification;
    public Animator AnimationNotif;

    public Animator PopupNotif;

    public GameObject CheckValidate;


    public void HaveANotification()
    {
        if (!AnimationNotif.GetBool("Play"))
        {
            if (ReadyToBeClaimed && !Complete)
            {
                ChallengeNotification.SetActive(true);
                AnimationNotif.SetBool("Play", true);
            }
        }
    }

    private void Start()
    {
        PopupNotif = GetComponent<Animator>();

        BurgerObjectif();
        MoneyObjectif();
        FanKickedObjectif();
        FanSatisfiedObjectif();
        ThreeStarsObjectif();
        AreaCompleteObjectif();
        StarsEarnedObjectif();

        if (Complete && AssociatedChallenge.ChallengeCompleted && NextChallenges.Count > 0)
        {
            Complete = false;
            ReadyToBeClaimed = false;
            NextIndex += 1;

            AssociatedChallenge = NextChallenges[NextIndex];
            ChallengeNameText.text = AssociatedChallenge.ChallengeName;
            Description.text = AssociatedChallenge.ChallengeText;

            BurgerObjectif();
            MoneyObjectif();
            FanKickedObjectif();
            FanSatisfiedObjectif();
            ThreeStarsObjectif();
            AreaCompleteObjectif();
        }

        ChallengeNameText.text = AssociatedChallenge.ChallengeName;
        Description.text = AssociatedChallenge.ChallengeText;

        if (PlayerPrefs.HasKey(AssociatedChallenge.ChallengeName))
        {
            Complete = true;
        }

        if (Complete && AssociatedChallenge.ChallengeCompleted)
        {
            PopupNotif.enabled = false;
            ReadyToBeClaimed = false;
            Logo.color = new Color32(125, 125, 125, 255);
            Fond.color = new Color32(125, 125, 125, 255);
            ChallengeNameText.color = new Color32(125, 125, 125, 255);
            Description.color = new Color32(125, 125, 125, 255);
            CheckValidate.SetActive(true);
        }

        HaveANotification();

        if (ReadyToBeClaimed && !Complete)
        {
            PopupNotif.SetBool("Play", true);
        }
        else if (!ReadyToBeClaimed || Complete)
        {
            PopupNotif.SetBool("Play", false);
        }
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
            GaugePercent.text = PlayerPrefs.GetInt("TotalStarsEarned") + " / " + AssociatedChallenge.StarsEarnedLimit;
            GaugeFill.fillAmount = PlayerPrefs.GetInt("TotalStarsEarned") / AssociatedChallenge.StarsEarnedLimit;

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

    public void Accomplish()
    {
        if (ReadyToBeClaimed && !AssociatedChallenge.ChallengeCompleted)
        {
            Reward.SetActive(true);

            PopupNotif.enabled = false;
            ReadyToBeClaimed = false;
            Logo.color = new Color32(125, 125, 125, 255);
            Fond.color = new Color32(125, 125, 125, 255);
            ChallengeNameText.color = new Color32(125, 125, 125, 255);
            Description.color = new Color32(125, 125, 125, 255);
            CheckValidate.SetActive(true);

            if (ReadyToBeClaimed && !Complete)
            {
                PopupNotif.SetBool("Play", true);
            }
            else if (!ReadyToBeClaimed || Complete)
            {
                PopupNotif.SetBool("Play", false);
            }

            if (AssociatedChallenge.DiamReward) {
                Reward.GetComponent<ChallengeReward>().AssociatedChallenge = AssociatedChallenge;
                Reward.GetComponent<ChallengeReward>().LogoImage.sprite = AssociatedChallenge.DiamLogo;
                Reward.GetComponent<ChallengeReward>().RewardQuantity.text = "+ " + AssociatedChallenge.RewardQuantity;
            }
            if (AssociatedChallenge.MoneyReward)
            {
                Reward.GetComponent<ChallengeReward>().AssociatedChallenge = AssociatedChallenge;
                Reward.GetComponent<ChallengeReward>().LogoImage.sprite = AssociatedChallenge.MoneyLogo;
                Reward.GetComponent<ChallengeReward>().RewardQuantity.text = "+ " +AssociatedChallenge.RewardQuantity;
            }
            ChallengeNotification.SetActive(false);
            AnimationNotif.SetBool("Play", false);
            Complete = true;
            ReadyToBeClaimed = false;
            AssociatedChallenge.ChallengeCompleted = true;
            PlayerPrefs.SetInt(AssociatedChallenge.ChallengeName, 1);
        }

        if (Complete && AssociatedChallenge.ChallengeCompleted && NextChallenges.Count > 0)
        {
            Complete = false;
            ReadyToBeClaimed = false;
            NextIndex += 1;

            AssociatedChallenge = NextChallenges[NextIndex];
            ChallengeNameText.text = AssociatedChallenge.ChallengeName;
            Description.text = AssociatedChallenge.ChallengeText;

            BurgerObjectif();
            MoneyObjectif();
            FanKickedObjectif();
            FanSatisfiedObjectif();
            ThreeStarsObjectif();
            AreaCompleteObjectif();
        }
    }

    [Button]
    public void Erase()
    {
        AssociatedChallenge.ChallengeCompleted = false;
        Complete = false;
        PlayerPrefs.DeleteKey(AssociatedChallenge.ChallengeName);
    }
}
