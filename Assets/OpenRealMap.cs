using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRealMap : MonoBehaviour
{
    public GameObject Map, MapToClose;

    public void Openmap()
    {
        Map.SetActive(true);
        MapToClose.SetActive(false);
    }
}
