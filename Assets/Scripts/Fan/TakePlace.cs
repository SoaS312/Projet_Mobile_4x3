using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TakePlace : MonoBehaviour
{


    public bool Moving =false;
    public bool needToLeave = false;
    public Transform SpawnPos;
    public Transform ChosenPlace;

    public bool hasResettedTime = false;

    public float lerpTime = 5; // Time it takes to reach
    public float currentLerpTime = 0;

    public void OnEnable()
    {
        Moving = true;
        SpawnPos = FollowersManager.staticFollowersManager.transform;
        FollowersManager.staticFollowersManager.TakePlaceFan();
        ChosenPlace = FollowersManager.staticFollowersManager.chosenPlaceGO.transform;
        hasResettedTime = false;
        currentLerpTime = 0;
    }

    public void Update()
    {
        if (Moving)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            if (!needToLeave)
                transform.position = Vector3.Lerp(SpawnPos.position, ChosenPlace.position, currentLerpTime / lerpTime);

            if (needToLeave) {
                if (!hasResettedTime)
                {
                    currentLerpTime = 0; hasResettedTime = true;
                }
            Leave();
        }
        }
    }

    [Button]
    public void Die()
    {
        FollowersManager.staticFollowersManager.Places.Add(ChosenPlace.gameObject);
        gameObject.SetActive(false);
        FollowersManager.staticFollowersManager.FanPooling.Add(this.gameObject);
    }

    [Button]
    public void Leave()
    {
        transform.position = Vector3.Lerp(ChosenPlace.position, SpawnPos.position, currentLerpTime/lerpTime);
        if (currentLerpTime >= lerpTime)
        {
            FollowersManager.staticFollowersManager.Places.Add(ChosenPlace.gameObject);
            gameObject.SetActive(false);
            FollowersManager.staticFollowersManager.FanPooling.Add(this.gameObject);
        }
    }
}
