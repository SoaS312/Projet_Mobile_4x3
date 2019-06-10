using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPeopleMind : MonoBehaviour
{
    [Range(0, 100)]
    public float speed = 5;

    public int MaterialIndex, GoingWay;
    public List<Material> Materials;
    public SkinnedMeshRenderer SMR;
    private float TimePop;
    public float maxTimePop;

    private void Start()
    {
        TimePop = 0;
        GoingWay = Random.Range(0, 2);
        MaterialIndex = Random.Range(0, Materials.Count);
        SMR.material = Materials[MaterialIndex];
    }

    void Update()
    {
        Move();

        TimePop += Time.deltaTime;

        if (TimePop >= maxTimePop)
        {
            gameObject.SetActive(false);
        }
    }

    private void Move()
    {
        if (!PauseMenu.staticPauseMenu.isPaused)
        {
            if (GoingWay == 0)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
                transform.Translate(Vector3.right * speed*2 * Time.deltaTime);
            }
        }
        else if (PauseMenu.staticPauseMenu.isPaused)
            transform.Translate(Vector3.zero);
    }
}
