using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedShaderTester : MonoBehaviour
{
    [SerializeField] private Material curvedSurfaceMat;
    // Start is called before the first frame update
    void Start()
    {
        curvedSurfaceMat.SetFloat("_BendFallOff", 17.0f);
        curvedSurfaceMat.SetFloat("_BendFallOffStr", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        curvedSurfaceMat.SetVector("_BendOrigin", transform.position);
        curvedSurfaceMat.SetVector("_BendAmount", new Vector3(0, -0.01f, (Mathf.Sin(Time.time) * 0.03f)));
    }
}
