using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthRotation : MonoBehaviour
{
    public void Update()
    {
        transform.Rotate(Vector3.up * -10 * Time.deltaTime, Space.Self);
    }
}
