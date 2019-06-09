using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RateOverTimeTest : MonoBehaviour
{
    public GameObject testPS;
    public int rate = 5;

    [Button]
    void Apply()
    {
        testPS.SetActive(true);
        var ratePS = testPS.GetComponent<ParticleSystem>().emission;
        ratePS.rateOverTime = rate;
    }
}
