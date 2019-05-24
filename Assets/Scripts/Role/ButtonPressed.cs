using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    public Image image;
    public Color32 iniColor;
    public Color32 SelectedColor = new Color32(255, 255, 255, 100);
    public GameObject holdButton;

    public void OnEnable()
    {
        image = this.gameObject.GetComponent<Image>();

            iniColor = image.color;

        holdButton = this.gameObject;
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
  //      image.color = iniColor;
    }

    public void onPress()
    {
        image.color = SelectedColor;
    }

    public void onRelease()
    {
        image.color = iniColor;
    }
}
