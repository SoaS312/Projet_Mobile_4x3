using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlace : MonoBehaviour
{
    public bool Moving =false;

    public Transform SpawnPos;
    public Transform RangementPos;
    public float speed;

    public void OnEnable()
    {
        Moving = true;
        SpawnPos = FollowersManager.staticFollowersManager.transform;
        RangementPos = FollowersManager.staticFollowersManager.RangementPlaces.transform;

        FollowersManager.staticFollowersManager.TakePlaceFan();


    }

    public void Update()
    {
        if (Moving)
        {
                transform.position = Vector3.MoveTowards(SpawnPos.position, RangementPos.position, speed * Time.deltaTime);
        }
    }
}
