using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness { 
public class SpawnBadSkieurs : MonoBehaviour {

    [Header("===Settings===")]
    public Vector3 position;
    public Vector3 size;
    public float timer;
    private float minTime;
    private float maxTime;

        [Header("===Timer (Easy Difficulty)==")]
        public float minEZTime;
        public float maxEZTime;
        [Header("===Timer (Medium Difficulty)===")]
        public float minMedTime;
        public float maxMedTime;
        [Header("===Timer (Hard Difficulty)===")]
        public float minHardTime;
        public float maxHardTime;




        [Header("===Fans===")]
    public List<GameObject> prefabs;
    public GameObject gameObjectSelected;

    // Use this for initialization
    void Start()
    {
        position = gameObject.transform.position;
            if (Difficulty.staticDifficulty.difficultyRate == 0)
            {
                minTime = minEZTime;
                maxTime = maxEZTime;
            }
            if (Difficulty.staticDifficulty.difficultyRate == 1)
            {
                minTime = minMedTime;
                maxTime = maxMedTime;
            }
            if (Difficulty.staticDifficulty.difficultyRate == 2)
            {
                minTime = minHardTime;
                maxTime = maxHardTime;
            }

            timer = Random.Range(minTime, maxTime);
        }

    // Update is called once per frame
    void Update()
    {
        Timing();
        Spawning();
        }

    void Spawning()
    {

        if (timer <= 0)
        {
            Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
                int index = Random.Range(0, prefabs.Count);
                gameObjectSelected = prefabs[index];
                Instantiate(gameObjectSelected, Pos, Quaternion.Euler(-270, 90, -90));
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
}

