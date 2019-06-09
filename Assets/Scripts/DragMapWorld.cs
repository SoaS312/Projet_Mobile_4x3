using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMapWorld : MonoBehaviour {
    /*public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 move;*/

    public Vector3 TouchStart;
    public float zoomOutMin;
    public float zoomOutMax;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TouchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
                Vector3 direction = TouchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Camera.main.transform.position += direction;

            Camera.main.transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20, 20), Mathf.Clamp(transform.position.y, -7.5f, 5), transform.position.z);


        }
        Zoom(Input.GetAxis("Mouse ScrollWheel"));

    }

    void Zoom(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }

}
