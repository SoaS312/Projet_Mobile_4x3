using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTruckState : MonoBehaviour
{

    public bool isDriverActive = true;
    public bool isVigileActive;
    public bool isSellerActive;
    public bool isCookActive;
    public bool isHelicoActive;
    public bool isScooterActive;
    public static FoodTruckState staticFoodTruckState;

    private AudioSource source;

    public AudioClip DriverSelec;
    public AudioClip VigileSelec;
    public AudioClip SellerSelec;
    public AudioClip CookSelec;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        staticFoodTruckState = this;
        isDriverActive = false;
        isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
    }

    public void ActivateDriver()
    {
        isDriverActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        if (!PlayerPrefs.HasKey("Sound"))
        {
            if (!source.isPlaying)
                source.PlayOneShot(DriverSelec, 1);
        }
    }
    public void ActivateVigile()
    {
        isVigileActive = true; isDriverActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        if (!PlayerPrefs.HasKey("Sound"))
        {
            if (!source.isPlaying)
                source.PlayOneShot(VigileSelec, 1);
        }
    }
    public void ActivateSeller()
    {
        isSellerActive = true; isVigileActive = false; isDriverActive = false; isCookActive = false; isHelicoActive = false; isScooterActive = false;
        if (!PlayerPrefs.HasKey("Sound"))
        {
            if (!source.isPlaying)
                source.PlayOneShot(SellerSelec, 1);
        }
    }
    public void ActivateCook()
    {
        isCookActive = true; isVigileActive = false; isSellerActive = false; isDriverActive = false; isHelicoActive = false; isScooterActive = false;
        if (!PlayerPrefs.HasKey("Sound"))
        {
            if (!source.isPlaying)
                source.PlayOneShot(CookSelec, 1);
        }
    }
    public void ActivateHelico()
    {
        isHelicoActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isDriverActive = false; isScooterActive = false;
    }
    public void ActivateScooter()
    {
        isScooterActive = true; isVigileActive = false; isSellerActive = false; isCookActive = false; isHelicoActive = false; isDriverActive = false;
    }
}
