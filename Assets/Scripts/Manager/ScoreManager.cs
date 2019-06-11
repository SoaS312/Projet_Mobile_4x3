using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using NaughtyAttributes;

public class ScoreManager : MonoBehaviour
{
    public static float money;        // The player's score.

    public TextMeshProUGUI text;                      // Reference to the Text component.


    void Awake()
    {
        money = 0;
    }


    void Update()
    {
        text.text = "" + Mathf.RoundToInt(money);
        LevelValues_HolderStatic.earnedMoney_Holded = Mathf.RoundToInt(money);
    }

    [Button]
    void GiveMeMoney()
    {
        money += 250;
    }
}
