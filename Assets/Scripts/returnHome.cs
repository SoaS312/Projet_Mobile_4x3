using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnHome : MonoBehaviour
{
    public void GetBackHome()
    {
        SceneManager.LoadScene("Test_UI", LoadSceneMode.Single);
        LevelValues_HolderStatic.SelledBurger_Holded = 0;
        LevelValues_HolderStatic.earnedMoney_Holded = 0;
    }
}
