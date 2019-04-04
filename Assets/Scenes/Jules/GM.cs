using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public GameObject Origine;
    public GameObject End;

    void Start()
    {
        Origine.SetActive(false);
        End.SetActive(false);

    }
    
    void Update()
    {
        if (FoodTruckState.staticFoodTruckState.isSellerActive)
        {
            Origine.SetActive(true);
            End.SetActive(true);
        }
        if (!FoodTruckState.staticFoodTruckState.isSellerActive)
        {
            Origine.SetActive(false);
            End.SetActive(false);
        }
    }
}
