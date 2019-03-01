using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GRP07_SkiMadness
{
    public class SpawnWaringSign : MonoBehaviour
    {
        public GameObject WarningSign;
        private GameObject instantiatedObj;
        
        void Start()
        {
            instantiatedObj = Instantiate(WarningSign, new Vector3(transform.position.x, -22, -35), new Quaternion(0,0,0,1));
        }

        void Update()
        {
            if (this.gameObject.GetComponent<Renderer>().isVisible)
            Destroy(instantiatedObj);
        }
    }
}
