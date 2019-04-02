using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int money;        // The player's score.

    public TextMeshProUGUI text;                      // Reference to the Text component.


    void Awake()
    {
        money = 0;
    }


    void Update()
    {
        text.text = "Money " +money;
    }
}
