using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public Transform Startpos, Endpos;

    public Vector3 p0, p1;

    public void Start()
    {
        p0 = new Vector3((Startpos.localPosition.x-transform.position.x), (Startpos.localPosition.y - transform.position.y), (Startpos.localPosition.z - transform.position.z));
        p1 = new Vector3((Endpos.localPosition.x-transform.position.x), (Endpos.localPosition.y - transform.position.y), (Endpos.localPosition.z - transform.position.z));
    }
}