
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFuelPomp : MonoBehaviour
{

    public bool isMooving;
    public bool isFueling;
    //public GameObject fuelPosition;
    Rigidbody rb;
    //private Vector3 init;
    public GameObject origin;
    public GameObject tuyeau;
    private GameObject fuelManager;
    public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        fuelManager = GameObject.Find("ControllManager");
        isMooving = false;
        rb = GetComponent<Rigidbody>();
        //init = new Vector3(-1.063f, 0.349f, -0.084f);
    }



    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && !isMooving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            //Debug.DrawRay(Camera.main.transform.position, Input.mousePosition, Color.red);
            //If we are clicking on the moveable object
            if (Physics.Raycast(ray, out hit, 100.0f, ~gameObject.layer))
            {
                if (hit.transform.tag == "Pompe")
                {
                    StartMovingObject();
                }
            }
        }

        if (Input.GetMouseButton(0) && isMooving)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Moving the moveable object
            if (Physics.Raycast(ray, out hit, 100.0f, layermask) && isMooving)
            {
                Vector3 hitPosition = hit.point - ray.direction * 0.5f;

                
            //transform.LookAt(hitPosition);
            transform.position = hitPosition;
            rb.velocity = Vector3.zero;
                

            }
        }

        if (Input.GetMouseButtonUp(0) && isMooving)
        {
            StopMovingObject();
        }

        
        if (isFueling)
        {
            
            //tuyeau.GetComponent<RopeControllerSimple>().enabled = false;
            fuelManager.GetComponent<Helico>().Buying();
        }
        else
        {
            tuyeau.GetComponent<RopeControllerSimple>().enabled = true;
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
        rb.velocity = Vector3.zero;
    }
    

 
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "FoodTruck")
        {
            isFueling = true;
            Debug.Log("fueling");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        isFueling = false;
    }



}
