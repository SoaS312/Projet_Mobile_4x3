using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Spawn : MonoBehaviour
    {

        [Header("===Settings===")]
        public Vector3 position;
        public Vector3 size;
        public float timer;
        public float minTime;
        public float maxTime;
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
                Vector3 Pos = position;
                obstaclesIndex = Random.Range(0, Obstacles.Count);
                gameObjectSelected = Obstacles[obstaclesIndex];
                Instantiate(gameObjectSelected, new Vector3(transform.position.x, gameObjectSelected.transform.position.y , transform.position.z), transform.rotation);
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
