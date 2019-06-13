
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFuelPomp : MonoBehaviour
{

    public bool isMooving;
    public bool isFueling;

    Rigidbody rb;

    public GameObject origin;
    public GameObject tuyeau;
    private GameObject fuelManager;
    public LayerMask layermask;

    public AudioClip FillFuel;

    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        fuelManager = GameObject.Find("ControllManager");
        isMooving = false;
        rb = GetComponent<Rigidbody>();
    }



    void Update()
    {
        

        if (Input.GetMouseButtonDown(0) && !isMooving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
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

            if (Physics.Raycast(ray, out hit, 100.0f, layermask) && isMooving)
            {
                Vector3 hitPosition = hit.point - ray.direction * 0.5f;

                
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
            if (!PlayerPrefs.HasKey("Sound"))
            {
                if(!source.isPlaying)
                source.PlayOneShot(FillFuel, 1);
            }
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
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        isFueling = false;
    }



}
