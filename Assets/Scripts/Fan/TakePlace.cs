using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlace : MonoBehaviour
{
    public List<GameObject> Places;
    public int chosenPlace;
    public Vector3 originalPos;
    public GameObject RangementPlaces;
    public float OffsetY;

    private void Awake()
    {
        RangementPlaces = RangementFanScript.staticRangementFanScript.gameObject;
        originalPos = transform.position;
    }

    private void Start()
    {

        for(int i = 0; i < RangementPlaces.transform.childCount; i++)
        {
            Places.Add(RangementPlaces.transform.GetChild(i).gameObject);
        }
        chosenPlace = Random.Range(0, Places.Count);
    }

    private void Update()
    {
        this.enabled = true;
        transform.position = new Vector3(Places[chosenPlace].transform.position.x, OffsetY, Places[chosenPlace].transform.position.z);
    }
}
