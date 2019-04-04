using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animVigile : MonoBehaviour
{
    public GameObject startposition;
    public bool isAttacking= false;
    private Transform fanposition;
    private Animator anim;

    private void Start()
    {
        fanposition = transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {   
        
       
        Kicking();

        if (!isAttacking)
        {
            transform.position = Vector3.Lerp(transform.position, startposition.transform.position, 0.05f);
        }

        if (isAttacking)
        {
            transform.position = Vector3.Lerp(transform.position, fanposition.position, 0.05f);
        }

    }

    private void Kicking()
    {
        if (FoodTruckState.staticFoodTruckState.isVigileActive)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if ((hit.transform.gameObject.tag == "Followers"))
                    {
                        //fanposition.position = ((hit.transform.position.x-0.2f), hit.transform.position.y, hit.transform.position.z);
                        fanposition.position = hit.transform.position + new Vector3(1f, 0, 0);
                        anim.SetTrigger("isAttacking");
                        //transform.position = Vector3.Lerp(transform.position, hit.transform.position, 0.1f);
                        isAttacking = true;
                    }

                }
            }
        }
    }

    public void GoTruck()
    { 
        isAttacking = false;
        Debug.Log("retour Camion !");
    }
}