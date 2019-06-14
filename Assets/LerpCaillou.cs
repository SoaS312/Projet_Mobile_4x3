using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCaillou : MonoBehaviour
{

    public Vector3 StartPos;
    public GameObject FoodTruck;

    [Range(0f, 1f)]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //StartPos = transform.position;
       // transform.position = Vector3.Lerp(StartPos, FoodTruck.transform.position, speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Detruire()
    {
        Destroy(this.gameObject);
    }

}
