using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRealMap : MonoBehaviour
{
    public GameObject Map, MapToClose, MainGauche, MainDroite;

    public void Openmap()
    {
        Map.SetActive(true);
        MapToClose.SetActive(false);
        MainGauche.SetActive(false);
        MainGauche.SetActive(false);
    }
}
