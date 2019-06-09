using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikesParticles : MonoBehaviour
{
    public static int LikesNumber;
    public static int LikesIndex;
    public int maxLikesIndex = 5;
    public static int DislikesNumber;

    public int DisplayLikes;
    public int DisplayDislikes;


    public void Start()
    {
        LikesNumber = 0;
        DislikesNumber = 0;
    }

    public void Update()
    {
        DisplayLikes = LikesNumber;
        DisplayDislikes = DislikesNumber;

        if (LikesIndex > maxLikesIndex)
        {
            LikesNumber += 1;
            LikesIndex = 0;
        }
    }


}
