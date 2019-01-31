using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public GameObject FoodTruck;
    public int MoneyEarn;
    public Cook cook;

    void Update()
    {
        Selling();
        cook = this.gameObject.GetComponent<Cook>();
    }

    private void Selling()
    {
        if (cook.readyFood > 0)
        {
            if (FoodTruckState.staticFoodTruckState.isSellerActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Followers")
                        {
                            cook.readyFood -= 1;
                            ScoreManager.money += MoneyEarn;
                        }

                    }
                }
            }
        }
    }
}
