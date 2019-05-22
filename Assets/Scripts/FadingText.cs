using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadingText : MonoBehaviour
{
    public void FadeIn()
    {
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<TextMeshProUGUI>()));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<TextMeshProUGUI>()));
    }

    public void Flash()
    {
        StartCoroutine(Flashing());
    }

    public IEnumerator Flashing()
    {
        while (GetComponent<TextMeshProUGUI>().outlineWidth < 0.25)
        {
            GetComponent<TextMeshProUGUI>().outlineWidth += 0.01f;
            yield return null;
        }
        while (GetComponent<TextMeshProUGUI>().outlineWidth >= 0.25)
        {
            while (GetComponent<TextMeshProUGUI>().outlineWidth > 0)
            {
                GetComponent<TextMeshProUGUI>().outlineWidth -= 0.01f;
                yield return null;
            }
        }
        FadeOut();
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
