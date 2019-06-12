using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public List<MeshRenderer> TruckMaterials;
    public Material StartMaterial;

    void Start()
    {
        SkinHolder.TruckMaterial = StartMaterial;
    }

    void Update()
    {
        for (int i = 0; i < TruckMaterials.Count; i++)
        {
            TruckMaterials[i].material = SkinHolder.TruckMaterial;
        }
    }
}
