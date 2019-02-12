using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePlace : MonoBehaviour
{
    public List<GameObject> Places;
    public int chosenPlace;
    public int speed = 10;
    public Vector3 originalPos;
    public GameObject RangementPlaces;

    private void Awake()
    {
        originalPos = transform.position;
    }

    private void Start()
    {
        chosenPlace = Random.Range(0, Places.Count);

        for(int i = 0; i < RangementPlaces.transform.childCount; i++)
        {
            Places.Add(RangementPlaces.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(originalPos.x, originalPos.y, Places[chosenPlace].transform.position.z);
    }
}
