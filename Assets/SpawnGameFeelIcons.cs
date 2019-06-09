using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;


public class SpawnGameFeelIcons : MonoBehaviour
{
    public List<GameObject> Icons;
    public int Index;

    public void Spawn()
    {
        if (Index < Icons.Count - 1)
        {
            Icons[Index].SetActive(true);
            Icons[Index].GetComponent<GoUp>().Timer = 0;
            Icons[Index].transform.position = transform.position;
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
