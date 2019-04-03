using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public GameObject GameManager;
    public int FuelEnMoins;

    public Transform camTransform;
    public float shakeTime = 0.5f;
    private float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            GameManager.GetComponent<FuelStock>().fuel -= FuelEnMoins;
            shakeDuration = shakeTime;
        }
    }
}
