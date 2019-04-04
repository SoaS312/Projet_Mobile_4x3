using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellerDrawlineController : MonoBehaviour
{
    public Transform origin;
    public Transform target;
    public LineRenderer lineRenderer;

    void Start()
    {
        
    }
    
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, target.position);

    }
}
