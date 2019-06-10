using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomPeople : MonoBehaviour
{
    public int IndexSpawn, IndexPeople;
    public List<GameObject> People;

    public GameObject LeftSpawn, RightSpawn;

    public float CurrentTime, maxTime, MinTime;

    public void Start()
    {
        IndexSpawn = Random.Range(0, 100);
        IndexPeople = -1;
        CurrentTime = Random.Range(MinTime, maxTime);
    }

    public void Update()
    {
        if ( CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        } else if (CurrentTime <= 0)
        {
            if (IndexSpawn >= 50)
            {
                Spawn(LeftSpawn);
            }
            else
            {
                Spawn(RightSpawn);
            }

            CurrentTime = Random.Range(MinTime, maxTime);
        }

    }

    public void Spawn(GameObject Spawner)
    {
        if (IndexPeople < People.Count - 1)
        {
            IndexPeople += 1;
        }
        else
        {
            IndexPeople = 0;
        }

        IndexSpawn = Random.Range(0, 100);
        People[IndexPeople].SetActive(true);
        People[IndexPeople].transform.position = new Vector3(Spawner.transform.position.x, transform.position.y, Spawner.transform.position.z);
    }
}
