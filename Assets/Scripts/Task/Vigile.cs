using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vigile : MonoBehaviour
{    
    public int attackValue;

    private void Start()
    {
        //attackValue = VigileUpgrade.staticVigileUpgrade.actualUpgradeValue;
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
                        hit.transform.GetComponent<FanManager>().life -= attackValue;
                    }

                }
            }
        }
    }
}
