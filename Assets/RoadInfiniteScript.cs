using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadInfiniteScript : MonoBehaviour
{
    public GameObject[] RoadPieces = new GameObject[2];
    const float RoadLength = 100f;

    const float RoadSpeed = 15f;
    void Update()
    {
        foreach (GameObject road in RoadPieces)
        {
            Vector3 newRoadPos = road.transform.position;
            newRoadPos.x -= RoadSpeed * Time.deltaTime;
            if (newRoadPos.x < -RoadLength / 2)
            {
                newRoadPos.x += RoadLength;
            }
            road.transform.position = newRoadPos;
        }
    }
}
