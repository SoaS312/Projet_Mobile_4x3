using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingArea : MonoBehaviour

{
    public bool zoomIn = false;
    public int ZoomFOV;
    public int speed;
    public Camera cam;

    private void Awake()
    {
        cam = this.GetComponent<Camera>();
    }

    void Update()
    {
        ZoomToRegion();

        if (zoomIn)
        {
            if (cam.fieldOfView > ZoomFOV)
            {
               cam.fieldOfView -= speed * Time.deltaTime;
            }

            if(cam.fieldOfView <= ZoomFOV)
            {
                GetComponentInChildren<ParticleSystem>().Stop();
            }
        }
    }

    private void ZoomToRegion()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "America")
                {
                    zoomIn = true;
                    GetComponentInChildren<ParticleSystem>().Play();
                }
            }
        }
    }
}
