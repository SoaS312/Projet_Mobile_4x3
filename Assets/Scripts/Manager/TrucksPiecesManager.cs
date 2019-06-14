using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrucksPiecesManager : MonoBehaviour
{
    public GameObject DriverPart;
    public GameObject CookPart;
    public GameObject SellerPart;
    public GameObject VigilePart;
    public GameObject VigilePerso;
    

    void Update()
    {
        if (this.GetComponent<FoodTruckState>().isCookActive)
        {
            CookPart.SetActive(true);
            SellerPart.SetActive(false);
            VigilePart.SetActive(false);
            VigilePerso.SetActive(false);
            DriverPart.SetActive(true);

        }
        if (this.GetComponent<FoodTruckState>().isVigileActive || this.GetComponent<FoodTruckState>().isHelicoActive || this.GetComponent<FoodTruckState>().isScooterActive || this.GetComponent<FoodTruckState>().isSellerActive)
        {
            CookPart.SetActive(true);
            SellerPart.SetActive(true);
            VigilePart.SetActive(true);
            DriverPart.SetActive(true);
            VigilePerso.SetActive(true);
        }
        if (this.GetComponent<FoodTruckState>().isHelicoActive)
        {
            CookPart.SetActive(true);
            SellerPart.SetActive(true);
            VigilePart.SetActive(true);
            DriverPart.SetActive(true);
            VigilePerso.SetActive(false);
        }

    }
}
