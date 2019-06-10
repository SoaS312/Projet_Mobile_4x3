using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRealMap : MonoBehaviour
{
    public GameObject Map;

    public void Openmap()
    {
        Map.SetActive(true);
        gameObject.SetActive(false);
    }
}
