using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class SpawnGameFeelIcons : MonoBehaviour
{
    public List<GameObject> Icons;
    public int Index;
    public float minXMove, maxXMove, minYMove, maxYMove, minZMove, maxZMove;
    public static SpawnGameFeelIcons staticSpawnGameFeelIcons;

    public Sprite FoodPlus, FuelPlus, MoneyPlus, LunchPlus;

    public void Start()
    {
        staticSpawnGameFeelIcons = this;
    }

    public void ForceFoodSpriteSpawn()
    {
        if (Index < Icons.Count - 1)
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<SpriteRenderer>().sprite = FoodPlus;
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.y - minYMove, transform.position.y + maxYMove), (Random.Range(transform.position.z - minZMove, transform.position.z + maxZMove)));
            Index += 1;
        }
        else
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<SpriteRenderer>().sprite = FoodPlus;
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.y - minYMove, transform.position.y + maxYMove), (Random.Range(transform.position.z - minZMove, transform.position.z + maxZMove)));
            Index = 0;
        }
    }

    public void ForceFuelSpriteSpawn()
    {
        if (Index < Icons.Count - 1)
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<SpriteRenderer>().sprite = FuelPlus;
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.y - minYMove, transform.position.y + maxYMove), (Random.Range(transform.position.z - minZMove, transform.position.z + maxZMove)));
            Index += 1;
        }
        else
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<SpriteRenderer>().sprite = FuelPlus;
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.y - minYMove, transform.position.y + maxYMove), (Random.Range(transform.position.z - minZMove, transform.position.z + maxZMove)));
            Index = 0;
        }
    }

    public void Spawn()
    {
        if (Index < Icons.Count - 1)
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.y - minYMove, transform.position.y + maxYMove), (Random.Range(transform.position.z- minZMove, transform.position.z + maxZMove)));
            Index += 1;
        }
        else
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.y - minYMove, transform.position.y + maxYMove), (Random.Range(transform.position.z - minZMove, transform.position.z + maxZMove)));
            Index = 0;
        }
    }
}
