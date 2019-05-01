using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GetLevelValues : MonoBehaviour
{
    public TextMeshProUGUI LevelName;

    public string GetSceneToLoad;

    public bool StarOne;
    public GameObject StarOneUI;
    public bool StarTwo;
    public GameObject StarTwoUI;
    public bool StarThree;
    public GameObject StarThreeUI;


    public TextMeshProUGUI FirstStarText;
    public TextMeshProUGUI SecondStarText;
    public TextMeshProUGUI ThirdStarText;



    [Button]
    public void Doit()
    {
        SetObjectivesNumber();
        GetValues();
    }

    private void GetValues()
    {
        LevelName.text = LevelValues_HolderStatic.LevelName_Holder;
        StarOne = LevelValues_HolderStatic.StarOne;
        StarTwo = LevelValues_HolderStatic.StarTwo;
        StarThree = LevelValues_HolderStatic.StarThree;
        GetSceneToLoad = LevelValues_HolderStatic.Scene;
     }

    public void LaunchGame()
    {
        SceneManager.LoadScene("LoadingScene", LoadSceneMode.Single);
    }


    private void SetObjectivesNumber()
    {
        if (LevelValues_HolderStatic.WhichObjective == "Burger")
        {
            FirstStarText.text = "Cook " + LevelValues_HolderStatic.ObjectiveKeys[0] + " lunches";
            SecondStarText.text = "Cook " + LevelValues_HolderStatic.ObjectiveKeys[1] + " lunches";
            ThirdStarText.text = "Cook " + LevelValues_HolderStatic.ObjectiveKeys[2] + " lunches";
        }

        if (LevelValues_HolderStatic.WhichObjective == "Money")
        {
            FirstStarText.text = "Reach " + LevelValues_HolderStatic.ObjectiveKeys[0] + " money";
            SecondStarText.text = "Reach " + LevelValues_HolderStatic.ObjectiveKeys[1] + " money";
            ThirdStarText.text = "Reach " + LevelValues_HolderStatic.ObjectiveKeys[2] + " money";
        }
    }



}
