using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTouchChangeRole : MonoBehaviour
{
    public GameObject hittedObject;
    public  UnityEvent BoolEvent;

    private void Awake()
    {
        hittedObject = this.gameObject;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject == hittedObject)
                {
                    BoolEvent.Invoke();
                }
            }
        }
    }
}
