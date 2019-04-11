using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using NaughtyAttributes;

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
        text.text = "" +money;
        LevelValues_HolderStatic.earnedMoney_Holded = money;
    }

    [Button]
    void GiveMeMoney()
    {
        money += 250;
    }
}
