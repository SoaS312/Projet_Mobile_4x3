using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UnityEngine.UI;


public class ChallengeReward : MonoBehaviour
{
    public TextMeshProUGUI RewardQuantity;
    public Image LogoImage;
    public Challenges AssociatedChallenge;

    public void Reward()
    {
        AssociatedChallenge.GetReward();
    }
}
