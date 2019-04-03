using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAnim : MonoBehaviour
{

    public AnimationCurve sautillement;
    public Vector3 iniScale;
    public float maxScaleX = 10;
    public float maxScaleY = 10;

    [Header("Timing")]
    public float second;
    public float JumpDuration;

    void Start()
    {
        iniScale = transform.localScale;
        second = 0;
    }

    void Update()
    {
        Timer();

    }

    void Timer()
    {
        if (second < JumpDuration)
        {
            second += Time.deltaTime;
            float percentTimer = second / JumpDuration;
            Hopping(percentTimer);
        }

        if (second >= JumpDuration)
        {
            second = 0;
        }
    }

    void Hopping(float jumpPercent)
    {
        float NewScaleX = Mathf.Lerp(iniScale.x, maxScaleX, sautillement.Evaluate(jumpPercent));
        float NewScaleY = Mathf.Lerp(iniScale.y, maxScaleY, sautillement.Evaluate(jumpPercent));
        transform.localScale = new Vector3(NewScaleX, NewScaleY, transform.position.z);

    }
}