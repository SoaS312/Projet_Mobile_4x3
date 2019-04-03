using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ObstacleTrigger : MonoBehaviour
{
    [HideIf("isObstacle")]
    public bool isBonus = false;
    [HideIf("isBonus")]
    public bool isObstacle = false;

    [ShowIf("isObstacle")]
    public Transform camTransform;
    [ShowIf("isObstacle")]
    public float shakeTime = 0.5f;
    [ShowIf("isObstacle")]
    private float shakeDuration = 0f;
    [ShowIf("isObstacle")]
    public float shakeAmount = 0.7f;
    [ShowIf("isObstacle")]
    public float decreaseFactor = 1.0f;
    [ShowIf("isObstacle")]
    Vector3 originalPos;

    [ShowIf("isBonus")]
    public bool isFuelBonus;
    [ShowIf("isBonus")]
    public bool isFoodBonus;
    [ShowIf("isBonus")]
    public bool isMoneyBonus;
    [ShowIf("isBonus")]
    public bool isInvicibleBonus;
    [ShowIf("isBonus")]
    public bool isAutoCookBonus;

    [ShowIf(ConditionOperator.Or, "isObstacle", "isFuelBonus")]
    public int FuelValue;

    void OnEnable()
    {
        camTransform = Camera.main.transform;
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        ShakingCamera();
    }

    private void ShakingCamera()
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
        if(other.tag == "FoodTruck" && isObstacle)
        {
            shakeDuration = shakeTime;
            FuelStock.staticFuelStock.fuel -= FuelValue;
            Destroy(gameObject);
        }

        if (other.tag == "FoodTruck" && isBonus && isFuelBonus)
        {
            FuelStock.staticFuelStock.fuel += FuelValue;
            Destroy(gameObject);
        }
    }
}
