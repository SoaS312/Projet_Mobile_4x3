/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSellerSelector : MonoBehaviour
{
    public GameObject EndLine;
    public GameObject Origin;

    private Vector3 mousePosition;
    private float deltaX, deltaY, deltaZ;


    void Start()
    {
        Origin.SetActive(false);
        EndLine.SetActive(false);
    }
    
    void Update()
    {


        Touch touch;
        if (Input.touchCount > 0)
            touch = Input.GetTouch(0);

        if (FoodTruckState.staticFoodTruckState.isSellerActive && Input.GetMouseButton(0))
        {
            Origin.SetActive(true);
            EndLine.SetActive(true);
            EndLine.transform.position = new Vector3 (-3.56f, 0.84f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
        }
    }


    /*private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
        EndLine.SetActive(true);
        Origin.SetActive(true);
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        deltaZ = Camera.main.ScreenToWorldPoint(Input.mousePosition).z - transform.position.z;
        EndLine.transform.position = new Vector3(deltaX, deltaY, deltaZ);
        }
        
    }
    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x - deltaX, mousePosition.y - deltaY, mousePosition.z - deltaZ);
    }

    private void OnMouseUp()
    {
        EndLine.SetActive(false);
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFuelPomp : MonoBehaviour
{

    bool isMooving;
    Rigidbody rb;
    //private Vector3 init;
    public GameObject origin;

    // Start is called before the first frame update
    void Start()
    {
        isMooving = false;
        rb = GetComponent<Rigidbody>();
        //init = new Vector3(-1.063f, 0.349f, -0.084f);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMooving)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //If we are clicing on the moveable object
            if (Physics.Raycast(ray, out hit, 100.0f, ~gameObject.layer))
            {
                StartMovingObject();
            }
        }

        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Moving the moveable object
            if (Physics.Raycast(ray, out hit, 100.0f, gameObject.layer) && isMooving)
            {
                Vector3 hitPosition = hit.point - ray.direction * 0.5f;

                //transform.LookAt(hitPosition);
                transform.position = hitPosition;
                /*transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));
                Debug.Log(hit.normal + " Hit.normal");
                Debug.Log(transform.right + " Transform.right");
                Debug.Log(Vector3.Cross(transform.right, hit.normal) + " Cross");*/





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

        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Followers")
            {
                Seller.staticSeller.cook.readyFood -= 1;
                ScoreManager.money += Seller.staticSeller.MoneyEarn;
                FollowersManager.staticFollowersManager.actualFollowPoints += Random.Range(25, 51);

            }
        }*/


    }

}
