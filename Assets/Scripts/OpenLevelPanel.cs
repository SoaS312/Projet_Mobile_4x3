using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class OpenLevelPanel : MonoBehaviour
{

    public void RelaunchAnim()
    {
        this.gameObject.GetComponent<Animator>().Play("LevelPanelAnimation", -1, 0f);
    }
}
