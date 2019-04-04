using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Dump;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle" || other.tag == "Bonus")
        {
            Spawn.staticSpawn.Obstacles.Add(other.gameObject);
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = Dump.transform.position;
        }

        if (other.tag == "Chunck")
        {
            ChuckSpawning.staticChuckSpawning.Chuncks.Add(other.gameObject);
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = Dump.transform.position;
        }
    }
}
