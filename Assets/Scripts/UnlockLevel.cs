using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public LevelValuesScriptable ActualLevel;
    private Button LevelButton;

    public Sprite UnlockedStar;

    public List<Image> Stars;

    public void Start()
    {
        LevelButton = GetComponent<Button>();
        CheckIfUnlockable();
        ActiveStars();
    }

    private void ActiveStars()
    {
        if (ActualLevel.isUnlocked == false)
        {

            foreach (Image Star in Stars)
            {
                Star.enabled = false;
            }
        }

        if (ActualLevel.isUnlocked == true)
        {
            foreach (Image Star in Stars)
            {
                Star.enabled = true;
            }

        }
    }

    private void CheckIfUnlockable()
    {

        if (ActualLevel.isUnlocked)
        {
            LevelButton.interactable = true;
        }

        if (ActualLevel.unlockedStars == 1)
        {
            Stars[0].sprite = UnlockedStar;
        }

        if (ActualLevel.unlockedStars == 2)
        {
            Stars[0].sprite = UnlockedStar;
            Stars[1].sprite = UnlockedStar;
        }

        if (ActualLevel.unlockedStars == 3)
        {
            Stars[0].sprite = UnlockedStar;
            Stars[1].sprite = UnlockedStar;
            Stars[2].sprite = UnlockedStar;
        }
    }
}
