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
    public GameObject followerManager;
    private Vector3 derriere;


    private void Start()
    {
        originalPos = transform.position;
        for (int i = 0; i < RangementPlaces.transform.childCount; i++)
        {
            Places.Add(RangementPlaces.transform.GetChild(i).gameObject);
        }
        chosenPlace = Random.Range(0, Places.Count);
    }

    private void Update()
    {
        //this.enabled = true;
        //derriere = new Vector3(Places[chosenPlace].transform.position.x, OffsetY, Places[chosenPlace].transform.position.z);
        transform.position = Vector3.Lerp(this.transform.position, Places[chosenPlace].transform.position, 0.01f);
    }
}
