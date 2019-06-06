using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeScript : MonoBehaviour
{

    public Transform camTransform;
    public float shakeTime = 0.5f;
    private float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    public AudioClip obstacleHit;
    public AudioClip bonusFood;
    public AudioClip bonusFuel;
    public AudioClip bonusNoFuelDecay;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

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
        if (other.tag == "Obstacle")
        {
            source.PlayOneShot(obstacleHit, 1);
            shakeDuration = shakeTime;
            if (!PlayerPrefs.HasKey("Vibrations"))
            {
                Handheld.Vibrate();
            }
        }

        if (other.tag == "Bonus" && other.gameObject.GetComponent<ObstacleTrigger>().isFuelBonus)
        {
            source.PlayOneShot(bonusFuel, 1);
        }


        if (other.tag == "Bonus" && other.gameObject.GetComponent<ObstacleTrigger>().isFoodBonus)
        {
            source.PlayOneShot(bonusFood, 1);
        }


        if (other.tag == "Bonus" && other.gameObject.GetComponent<ObstacleTrigger>().isNoFuelDecayBonus)
        {
            source.PlayOneShot(bonusNoFuelDecay, 1);
        }

    }
}
