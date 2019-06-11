using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopEffect : MonoBehaviour
{

    public AnimationCurve Pop;
    public Vector3 iniPos;
    public float maxJumpY;

    [Header("Timing")]
    public float second;
    public float JumpDuration;

    void Start()
    {
        iniPos = new Vector3(0, 0, 0);
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
    }

    void Hopping(float jumpPercent)
    {
            float newScale = Mathf.Lerp(iniPos.x, maxJumpY, Pop.Evaluate(jumpPercent));
            transform.localScale = new Vector3(newScale, newScale, newScale);

    }
}
