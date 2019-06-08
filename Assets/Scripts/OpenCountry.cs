using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenCountry : MonoBehaviour
{
    public static GameObject ZoneLevelToShow;
    public static GameObject RetourMapAActiver;
    public static GameObject MapPlanisphere;
    public TextMeshProUGUI TripName;

    public void Close()
    {
        GetComponent<Animator>().SetBool("Open", false);
        GetComponent<Animator>().SetBool("Close", true);
    }

    public void GoPowerRangers()
    {
        ZoneLevelToShow.SetActive(true);
        RetourMapAActiver.SetActive(true);
        MapPlanisphere.SetActive(false);
        GetComponent<Animator>().SetBool("Open", false);
        GetComponent<Animator>().SetBool("Close", true);
    }

    public void Diable()
    {
        this.gameObject.SetActive(false);
    }
}
