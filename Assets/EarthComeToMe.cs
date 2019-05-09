using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthComeToMe : MonoBehaviour
{
    public bool Coming = false;
    public Vector3 DesiredPos;
    public float speed;

    public void Come()
    {
        Coming = true;
    }

    public void Update()
    {
        if (Coming && transform.position.z > DesiredPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z - speed));
        }

        if (transform.position.z < 40)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 40);
        }
    }
}
