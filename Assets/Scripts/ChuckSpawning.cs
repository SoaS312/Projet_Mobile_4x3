﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckSpawning : MonoBehaviour
{

    public bool isLeft;
    public bool isRight;

    [Header("===Settings===")]
    public Vector3 position;
    public Vector3 size;
    public float timer;
    public float minTime;
    public float maxTime;

    [Header("===Fans===")]
    public List<GameObject> Chuncks;
    public GameObject gameObjectSelected;

    public static ChuckSpawning staticChuckSpawning;

    void Start()
    {
        staticChuckSpawning = this;
        position = gameObject.transform.position;
        //timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        Timing();
        Spawning();

    }

    void Spawning()
    {

        if (Input.GetKeyDown("l") || timer <= 0)
        {
            Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
            int index = Random.Range(0, Chuncks.Count);
            gameObjectSelected = Chuncks[index];
            if (isLeft)
            {
                gameObjectSelected.transform.position = Pos;
                gameObjectSelected.SetActive(true);
                Chuncks.Remove(gameObjectSelected);
                //Instantiate(gameObjectSelected, Pos, transform.rotation);
            }
            timer = Random.Range(minTime, maxTime);
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
