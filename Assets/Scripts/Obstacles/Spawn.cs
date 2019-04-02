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
        public GameObject associateRoad;
        public int offsetX;

        [Header("===Obstacles===")]
        public GameObject gameObjectSelected;
        public int index;

        [Header("===OnGoing===")]
        public List<GameObject> Obstacles;

        void Start()
        {
            timer = Random.Range(minTime, maxTime);
            transform.position = new Vector3(associateRoad.transform.position.x + offsetX, transform.position.y, transform.position.z);
            position = gameObject.transform.position;
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
                timer = Random.Range(minTime, maxTime);
                Vector3 Pos = position;
                index = Random.Range(0, Obstacles.Count);
                gameObjectSelected = Obstacles[index];
                Instantiate(gameObjectSelected, new Vector3(Pos.x, gameObjectSelected.transform.position.y ,Pos.z), transform.rotation);
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
