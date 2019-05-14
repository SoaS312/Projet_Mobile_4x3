using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunckSpawnStarter : MonoBehaviour
{
    public bool spawnOnce = false;
    public static ChunckSpawnStarter staticChunckStarterSpawning;

    public ChuckSpawning ChunckSpawner;

    [Header("===Settings===")]
    public Vector3 position;
    public Vector3 size;

    [Header("===Fans===")]
    public List<GameObject> Chuncks;
    public GameObject gameObjectSelected;


    void Start()
    {
        staticChunckStarterSpawning = this;
        position = gameObject.transform.position;
        Spawning();
    }

    void Spawning()
    {
            Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
            int index = Random.Range(0, Chuncks.Count);
            gameObjectSelected = ChunckSpawner.Chuncks[index];
            gameObjectSelected.transform.position = Pos;
            gameObjectSelected.SetActive(true);
        ChunckSpawner.Chuncks.Remove(gameObjectSelected);
    }
}