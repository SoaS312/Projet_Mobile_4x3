using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTruck : MonoBehaviour
{
    public Transform FoodTruck;
    public float OffsetZ;

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, FoodTruck.position.z + OffsetZ);
    }
}
