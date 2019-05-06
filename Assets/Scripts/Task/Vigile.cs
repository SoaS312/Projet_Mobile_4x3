using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vigile : MonoBehaviour
{    
    public int attackValue;
    public CrewUpgradeScriptable VigileLevel;

    private void Start()
    {
        attackValue = VigileLevel.CrewUpgradeList[VigileLevel.CrewLevelIndex];
    }

    void Update()
    {
        Kicking();
    }

    private void Kicking()
    {
        if (FoodTruckState.staticFoodTruckState.isVigileActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Followers")
                    {
                        Debug.Log("Je te casse la tête");
                        hit.transform.GetComponent<FanManager>().life -= attackValue;
                    }

                }
            }
        }
    }
}
