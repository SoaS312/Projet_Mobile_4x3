using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangementFanScript : MonoBehaviour
{
    public static RangementFanScript staticRangementFanScript;

    public void Awake()     
    {
        staticRangementFanScript = this;
    }
}
