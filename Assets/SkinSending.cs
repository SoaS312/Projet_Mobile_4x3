using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSending : MonoBehaviour
{
    public Material Skin;

    public void SendSkin()
    {
        SkinHolder.TruckMaterial = Skin;
    }
}
