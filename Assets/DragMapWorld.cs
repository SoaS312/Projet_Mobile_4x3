using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMapWorld : MonoBehaviour {
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 move;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);


            move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

        transform.Translate(move, Space.World);

        if (transform.position.x > 20)
        {
            transform.position = new Vector3(20,transform.position.y, 0);
        }else if (transform.position.x < -20)
        {
            transform.position = new Vector3(-20, transform.position.y, 0);
        }

        if (transform.position.y > 10)
        {
            transform.position = new Vector3(transform.position.x, 10, 0);
        }
        else if (transform.position.y < -10)
        {
            transform.position = new Vector3(transform.position.x, -10, 0);
        }

    }
}
