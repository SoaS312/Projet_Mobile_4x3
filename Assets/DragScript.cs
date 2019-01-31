using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{

    public float rotSpeed = 20;

    void OnMouseDrag()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime;

        //transform.RotateAround(Vector3.up, -rotX);
        //transform.RotateAround(Vector3.right, rotY);

        transform.Rotate(Vector3.up, -rotX, Space.World);
        transform.Rotate(Vector3.right,rotY, Space.World);
    }
}
