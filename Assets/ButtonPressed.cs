using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    public Image image;
    public Color32 iniColor;
    public bool isStartingTask;
    public Color32 SelectedColor = new Color32(255, 255, 255, 100);

    public void Awake()
    {
        image = this.gameObject.GetComponent<Image>();

        if (!isStartingTask)
            iniColor = image.color;
        else
            image.color = SelectedColor;
    }

    public void Update()
    {
        image = this.gameObject.GetComponent<Image>();
    }

    public void isSelected()
    {
        image.color = SelectedColor;
    }

    public void RevertColor()
    {
        image.color = iniColor;
    }
}
