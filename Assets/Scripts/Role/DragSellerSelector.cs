using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSellerSelector : MonoBehaviour
{

    bool isMooving;
    Rigidbody rb;
    public GameObject origin;

    void Start()
    {
        isMooving = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMooving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f, ~gameObject.layer) && FoodTruckState.staticFoodTruckState.isSellerActive)
            {
                StartMovingObject();
            }
        }

        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f, gameObject.layer) && isMooving)
            {
                Vector3 hitPosition = hit.point - ray.direction*0.5f;
                
                transform.position = hitPosition;
                rb.velocity = Vector3.zero;

            }
        }

        if (Input.GetMouseButtonUp(0) && isMooving)
        {
            StopMovingObject();
        }
    }

    void StartMovingObject()
    {
        isMooving = true;
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
    }

    void StopMovingObject()
    {
        isMooving = false;
        rb.freezeRotation = false;
        this.transform.position = origin.transform.position;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.transform.gameObject.tag == "Followers" && Seller.staticSeller.cook.readyFood > 0)
            {
                PlayerPrefs.SetInt("TotalSelledBurger", PlayerPrefs.GetInt("TotalSelledBurger") + 1);
                Seller.staticSeller.cook.readyFood -= 1;
                ScoreManager.money += Seller.staticSeller.MoneyEarn;
                PlayerPrefs.SetInt("TotalMoneyEarned", PlayerPrefs.GetInt("TotalMoneyEarned") + Seller.staticSeller.MoneyEarn);
                FollowersManager.staticFollowersManager.actualFollowPoints += Random.Range(25, 51);
                hit.transform.gameObject.GetComponent<FanManager>().burgerEated += 1;
                hit.transform.gameObject.GetComponent<FanManager>().BeHappy(1f);
                hit.transform.gameObject.GetComponent<FanManager>().secondsBeingWaiting = 0;

            }
        }

            
    }
    
}
