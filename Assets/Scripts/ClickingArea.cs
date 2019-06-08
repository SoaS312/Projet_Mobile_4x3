using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using NaughtyAttributes;
using TMPro;

public class ClickingArea : MonoBehaviour
{
    public string AreaName;
    public GameObject ZoneLevelToShow;
    public GameObject RetourMapAActiver;
    private GameObject MapPlanisphere;
    public GameObject GoCountryPanel;

    public void Start()
    {
        MapPlanisphere = transform.parent.gameObject;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > (0))
            {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.transform.name)
                {
                    GoCountryPanel.SetActive(true);
                    GoCountryPanel.GetComponent<OpenCountry>().TripName.text = "Go to " + AreaName + " ?";
                    OpenCountry.ZoneLevelToShow = ZoneLevelToShow;
                    OpenCountry.RetourMapAActiver = RetourMapAActiver;
                    OpenCountry.MapPlanisphere = MapPlanisphere;
                    GoCountryPanel.GetComponent<Animator>().SetBool("Open", true);
                }

            }
        }
    }
}
