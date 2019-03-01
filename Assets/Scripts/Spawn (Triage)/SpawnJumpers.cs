using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class SpawnJumpers : MonoBehaviour
    {
        public GameObject Jumpers;
        public float timer;
        public float minTime;
        public float maxTime;
        public Vector3 position;
        public Vector3 size;

        void Update()
        {
            Timing();
            Spawning();
        }

        void Timing()
        {

            if (timer > 0)
                timer -= Time.deltaTime;

        }

        void Spawning()
        {

            if (timer <= 0)
            {
                timer = Random.Range(minTime, maxTime);
                Vector3 Pos = position + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0, 0);
                Instantiate(Jumpers, Pos, Quaternion.Euler(90, -90, 90));
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(position, size);
        }
    }
}
