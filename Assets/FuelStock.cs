using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelStock : MonoBehaviour
{
    public static FuelStock staticFuelStock;
    public float fuel;
    public float maxFuel;
    public bool isDry;
    public Image stockFuel;

    // Start is called before the first frame update
    void Start()
    {
        fuel = maxFuel;
        isDry = false;
    }

    // Update is called once per frame
    void Update()
    {
        stockFuel.fillAmount = fuel / maxFuel;


       fuel -= Time.deltaTime*3;

        if (fuel <= 0)
        {
            fuel = 0;
            isDry = true;
        }
    }
}
