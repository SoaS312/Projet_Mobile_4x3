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
                Debug.Log(hit.transform.name);

                if (hit.transform.name == gameObject.transform.name)
                {
                    ZoneLevelToShow.SetActive(true);
                    RetourMapAActiver.SetActive(true);
                    MapPlanisphere.SetActive(false);
                }

            }
        }
    }
}
