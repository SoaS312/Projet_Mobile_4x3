using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class TakePlace : MonoBehaviour
{


    public bool needToLeave = false;
    public Transform SpawnPos;
    public Transform ChosenPlace;

    public bool hasResettedTime = false;

    public float lerpTime = 2;
    public float currentCOMELerpTime = 0;

    public float currentLEAVELerpTime = 0;

    public void OnEnable()
    {
        SpawnPos = FollowersManager.staticFollowersManager.transform;
        FollowersManager.staticFollowersManager.TakePlaceFan();
        ChosenPlace = FollowersManager.staticFollowersManager.chosenPlaceGO.transform;
        currentCOMELerpTime = 0;
        currentLEAVELerpTime = 0;
        needToLeave = false;
    }

    public void Update()
    {
            currentCOMELerpTime += Time.deltaTime;
            if (currentCOMELerpTime >= lerpTime)
            {
                currentCOMELerpTime = lerpTime;
            }
            if (!needToLeave)
                transform.position = Vector3.Lerp(SpawnPos.position, ChosenPlace.position, currentCOMELerpTime / lerpTime);

            if (needToLeave)
            {
                Leave();
            }
 
        if (currentLEAVELerpTime < lerpTime && needToLeave)
        {
            currentLEAVELerpTime += Time.deltaTime;
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
        transform.position = Vector3.Lerp(ChosenPlace.position, SpawnPos.position, currentLEAVELerpTime / lerpTime);
        if (currentLEAVELerpTime >= lerpTime)
        {
            FollowersManager.staticFollowersManager.actualFollowers.Remove(this.gameObject);
            FollowersManager.staticFollowersManager.Places.Add(ChosenPlace.gameObject);
            gameObject.SetActive(false);
            FollowersManager.staticFollowersManager.FanPooling.Add(this.gameObject);
        }
    }
}
