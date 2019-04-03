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
        if (FoodTruckState.staticFoodTruckState.isDriverActive || FoodTruckState.staticFoodTruckState.isCookActive)
        stockedDirection = data.Direction.ToString();
    }
}