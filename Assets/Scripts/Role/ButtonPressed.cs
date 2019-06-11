using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressed : MonoBehaviour
{
    public Image image, FondImage;
    public Sprite selectedImage, originalImage;
    public Color32 iniColor;
    public Color32 SelectedColor = new Color32(255, 255, 255, 100);

    public void isSelected()
    {
        image.sprite = selectedImage;
        FondImage = this.GetComponent<Image>();
        FondImage.color = SelectedColor;
        //image.color = SelectedColor;
    }

    public void RevertColor()
    {
        image.sprite = originalImage;
        FondImage = this.GetComponent<Image>();
        FondImage.color = iniColor;
        //image.color = iniColor;
    }
}
