using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class SpawnFan : MonoBehaviour { 

       [Header("===Settings===")]
        public Vector3 position;
        public Vector3 size;
        public float timer;
        public float minTime;
        public float maxTime;
        public float iniMinTime;
        public float iniMaxTime;
        public float TimeMultiplier;
        public bool spawnGauche;

        [Header("===Fans===")]
        public List<GameObject> prefabs;
        public GameObject gameObjectSelected;

    // Use this for initialization
    void Start()
    {
        position = gameObject.transform.position;
        timer = Random.Range(minTime, maxTime);
            minTime = iniMaxTime;
            maxTime = iniMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        Timing();
        Spawning();

            TimeMultiplier += Time.deltaTime;

            if (minTime > 0.1f)
            {
                minTime = iniMinTime / TimeMultiplier;
            }

            if (maxTime > 0.1f)
            {
                maxTime = iniMaxTime / TimeMultiplier;
            }

    }

    void Spawning()
    {

        if (Input.GetKeyDown("l") || timer <= 0)
        {
            Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
                int index = Random.Range(0, prefabs.Count);
                gameObjectSelected = prefabs[index];
                if (spawnGauche)
                {
                    Instantiate(gameObjectSelected, Pos, Quaternion.Euler(-360, 90, -90));
                }
                else
                {
                    Instantiate(gameObjectSelected, Pos, Quaternion.Euler(-180, 90, -90));
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
}
