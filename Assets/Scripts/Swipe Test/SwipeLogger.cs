using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    public static SwipeLogger staticSwipeLogger;
    public string stockedDirection;

    public void Awake()
    {
        staticSwipeLogger = this;
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    public void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
        stockedDirection = data.Direction.ToString();
    }
}