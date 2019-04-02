using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTouch : MonoBehaviour
{

    public float speed = 10f;
    public Vector3 targetPos;
    public bool isMoving;
    const int MOUSE = 0;

    public float minX = -1.5f, maxX = 6.0f;// we want to keep the y between 0 and 10
    public float minZ = -0.8f, maxZ = 1.8f;// we want to keep the y between 0 and 10
    // Use this for initialization1
    void Start()
    {

        targetPos = transform.position;

    }

    private void FixedUpdate()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            Time.timeScale = 0;

        // if (Input.GetMouseButton(MOUSE))

        SetTarggetPosition();

        ///////////
        // get the position to a variable
        Vector3 currentPosition = transform.position;
        // modify the variable to keep y within minY to maxY
        currentPosition.x =
           Mathf.Clamp(currentPosition.x, minX, maxX);
        // and now set the transform position to our modified vector
        transform.position = currentPosition;

        // get the position to a variable
        Vector3 currentPositionZ = transform.position;
        // modify the variable to keep y within minY to maxY
        currentPositionZ.z =
           Mathf.Clamp(currentPositionZ.z, minZ, maxZ);
        // and now set the transform position to our modified vector
        transform.position = currentPositionZ;


    }


    void SetTarggetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPos = ray.GetPoint(point);
         Debug.DrawLine(new Vector3(0,0,0) , targetPos, Color.red, 1);

    }
}