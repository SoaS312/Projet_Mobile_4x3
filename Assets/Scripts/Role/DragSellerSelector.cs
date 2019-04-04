using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSellerSelector : MonoBehaviour
{
    public GameObject EndLine;


    void Start()
    {
        
    }
    
    void Update()
    {
        Touch touch = Input.GetTouch(0);

        if (GetComponent<FoodTruckState>().isCookActive && Input.GetMouseButtonUp(0))
        {
            EndLine.SetActive(true);
            EndLine.transform.position = Input.mousePosition;
        }
    }
}
