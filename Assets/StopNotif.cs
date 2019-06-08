using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopNotif : MonoBehaviour
{
    public GameObject ChallengeNotification;
    public Animator AnimationNotif;

    public void StopAllNotification()
    {
        ChallengeNotification.SetActive(false);
        AnimationNotif.SetBool("Play", false);
    }

    public void StopAnimationNotifOnly()
    {
        AnimationNotif.SetBool("Play", false);
    }
}
