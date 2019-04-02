using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    public int life = 100;

    void Update()
    {

        if (life <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
