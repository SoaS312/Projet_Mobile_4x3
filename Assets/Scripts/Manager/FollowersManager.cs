using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowersManager : MonoBehaviour
{
    public static FollowersManager staticFollowersManager;
    public int maxFollowPoints;
    public int actualFollowPoints;
    public List<GameObject> Follower;

    public List<GameObject> actualFollowers;
    public int maxFollowersBeforeAngry;
    public int maxFollowersOnScreen;

    public float OffsetY;

    void Start()
    {
        Instantiate(Follower[Random.Range(0, Follower.Count)], this.transform);
        staticFollowersManager = this;
        maxFollowPoints = Random.Range(50, 101);
    }

    void Update()
    {
        SpawnFollowers();

        /*if (actualFollowers.Count >= maxFollowersBeforeAngry)
        {
            //do test for smash
        }*/

    }

    private void SpawnFollowers()
    {
        if (actualFollowers.Count < maxFollowersOnScreen)
        {
            if (actualFollowPoints >= maxFollowPoints)
            {
                maxFollowPoints = Random.Range(50, 101);
                actualFollowPoints = 0;
                GameObject followi = Instantiate(Follower[Random.Range(0, Follower.Count)], this.transform);
                actualFollowers.Add(followi);
            }
        }
    }
}
