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

    public void ZoomToRegion()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > (0))
            {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.transform.name)
                {
                    Debug.Log("Do Something");
                }

            }
        }
    }
}
