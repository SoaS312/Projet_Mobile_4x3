using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRealMap : MonoBehaviour
{
    public GameObject Map, MapToClose, MainGauche, MainDroite;
    public DragMapWorld l;

    public void Openmap()
    {
        l.enabled = true;
        Map.SetActive(true);
        MapToClose.SetActive(false);
        MainGauche.SetActive(false);
        MainDroite.SetActive(false);
    }
}
