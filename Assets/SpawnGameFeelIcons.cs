using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class SpawnGameFeelIcons : MonoBehaviour
{
    public List<GameObject> Icons;
    public int Index;
    public float minXMove, maxXMove, minYMove, maxYMove;

    public void Spawn()
    {
        if (Index < Icons.Count - 1)
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = new Vector3(Random.Range(transform.position.x - minXMove, transform.position.x + maxXMove), Random.Range(transform.position.x - minYMove, transform.position.x + maxYMove), transform.position.z);
            Index += 1;
        }
        else
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = transform.position;
            Index = 0;
        }
    }

    [Button]
    void SpawnItLikeYouPlayed()
    {
        Spawn();
    }


}
