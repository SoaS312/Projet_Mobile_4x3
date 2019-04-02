using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    [Range(5,50)] // 5 = super fast 50 = super slow
    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed/100);
    }
}
