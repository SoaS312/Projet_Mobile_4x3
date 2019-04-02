using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class ClickingArea : MonoBehaviour

{
    public bool zoomIn = false;
    public int ZoomFOV;
    public int speed;
    public Camera cam;
    public UnityEvent ClickEvent;
    public GameObject NuageEffect;

    private void Awake()
    {
       // cam = this.GetComponent<Camera>();
    }

    public void Update()
    {
        ZoomToRegion();

        if (zoomIn)
        {
            if (cam.fieldOfView > ZoomFOV)
            {
                cam.fieldOfView -= speed * Time.deltaTime;
            }

            if (cam.fieldOfView <= ZoomFOV)
            {
                NuageEffect.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    public void ZoomToRegion()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > (0))
            {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == gameObject.transform.name)
                zoomIn = true;
                NuageEffect.GetComponent<ParticleSystem>().Play();
                DesactiveObj();

                foreach (Transform child in hit.transform)
                {
                    child.gameObject.SetActive(true);
                }

            }
        }
    }

    public void DesactiveObj()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
