using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    [Header("===Settings===")]
    public Vector3 position;
    public Vector3 size;
    public float timer;
    public float minTime = 3;
    public float maxTime = 6;
    public List<GameObject> Roads;
    private int roadsIndex;
    public GameObject associateRoad;
    public int offsetX;

    [Header("===Obstacles===")]
    public GameObject gameObjectSelected;
    private int obstaclesIndex;

    [Header("===OnGoing===")]
    public List<GameObject> Obstacles;
    public static Spawn staticSpawn;

    public GameObject ValuesHolder;

    private void Awake()
    {
        ValuesHolder = LevelValues_HolderStatic.LevelValuesHolder;
        minTime = LevelValues_HolderStatic.minTime_Holded;
        maxTime = LevelValues_HolderStatic.maxTime_Holded;
    }

    void Start()
    {
        staticSpawn = this;
        ChooseRoad();
        timer = Random.Range(minTime, maxTime);
    }

    private void ChooseRoad()
    {
        roadsIndex = Random.Range(0, Roads.Count);
        associateRoad = Roads[roadsIndex];
        transform.position = new Vector3(associateRoad.transform.position.x + offsetX, transform.position.y, associateRoad.transform.position.z);
    }

    void Update()
    {
        Timing();
        Spawning();
    }

    void Spawning()
    {

        if (timer <= 0)
        {
            ChooseRoad();
            timer = Random.Range(minTime, maxTime);

            obstaclesIndex = Random.Range(0, Obstacles.Count);
            gameObjectSelected = Obstacles[obstaclesIndex];
            gameObjectSelected.transform.position = transform.position;

            gameObjectSelected.SetActive(true);
            Obstacles.Remove(gameObjectSelected);
        }
    }

    void Timing()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(position, size);
    }
}
