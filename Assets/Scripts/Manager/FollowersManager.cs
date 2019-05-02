using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersManager : MonoBehaviour
{
    public static FollowersManager staticFollowersManager;


    public List<GameObject> FanPooling;
    public int FanIndex;
    public GameObject chosenFan;

    public List<GameObject> Places;
    public GameObject RangementPlaces;
    public int chosenPlace;


    public int maxFollowPoints;
    public float actualFollowPoints;
    public List<GameObject> Follower;

    public List<GameObject> actualFollowers;
    public int maxFollowersBeforeAngry;
    public int maxFollowersOnScreen;

    public float OffsetY;


    void Start()
    {
        RangementPlaces = RangementFanScript.staticRangementFanScript.gameObject;
        staticFollowersManager = this;
        maxFollowPoints = Random.Range(50, 101);

        for (int i = 0; i < RangementPlaces.transform.childCount; i++)
        {
            Places.Add(RangementPlaces.transform.GetChild(i).gameObject);
        }
        chosenPlace = Random.Range(0, 15);
    }

    void Update()
    {
        SpawnFollowers();

    }

    private void SpawnFollowers()
    {
        if (actualFollowers.Count < maxFollowersOnScreen)
        {
               actualFollowPoints += 10 * Time.deltaTime; ;
            if (actualFollowPoints >= maxFollowPoints && FanPooling.Count > 0)
            {
                maxFollowPoints = Random.Range(50, 101);
                actualFollowPoints = 0;
                FanIndex = Random.Range(0, FanPooling.Count);
                chosenFan = FanPooling[FanIndex];
                chosenFan.SetActive(true);
                FanPooling.Remove(chosenFan);
                actualFollowers.Add(chosenFan); //On ajoute le followers à l'actual list
            }
        }
    }

    public void TakePlaceFan()
    {
        chosenPlace = Random.Range(0, Places.Count);
        RangementPlaces = Places[chosenPlace];
        Places.Remove(RangementPlaces);
    }
}
