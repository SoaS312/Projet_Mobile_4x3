using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    public Button Small;
    public Button Med;
    public Button Large;

    void DisableBuying()
    {
        Small.interactable = false; Med.interactable = false; Large.interactable = false;
    }

    void EnableBuying()
    {
        Small.interactable = true; Med.interactable = true; Large.interactable = true;
    }

    void DisableThisFockingPanel()
    {
        this.gameObject.SetActive(false);
    }
}
