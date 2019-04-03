using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusUpgradeAnim : MonoBehaviour
{

    public AnimationCurve sautillement;
    public Vector3 iniPos;
    public float maxJumpY = 10;

    [Header("Timing")]
    public float second;
    public float JumpDuration;

    void Start()
    {
        iniPos = transform.position;
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
        float newZ = Mathf.Lerp(iniPos.y, maxJumpY, sautillement.Evaluate(jumpPercent));
        transform.position = new Vector3(transform.position.x, newZ, transform.position.z);

    }
}
