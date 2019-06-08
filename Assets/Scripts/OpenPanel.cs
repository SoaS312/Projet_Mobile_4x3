using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public bool Open = false;

    public void ShowHide()
    {
        if (!Open && !this.gameObject.GetComponent<Animator>().GetBool("Show"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Show", true);
            this.gameObject.GetComponent<Animator>().SetBool("Hide", false);
        }
        else if (this.gameObject.GetComponent<Animator>().GetBool("Show"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("Show", false);
            this.gameObject.GetComponent<Animator>().SetBool("Hide", true);
        }
    }

    public void OpenPanelFunction()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Show", true);
        this.gameObject.GetComponent<Animator>().SetBool("Hide", false);
    }

    public void ClosePanelFunction()
    {
        this.gameObject.GetComponent<Animator>().SetBool("Show", false);
        this.gameObject.GetComponent<Animator>().SetBool("Hide", true);
    }

    public void Disabling()
    {
        this.gameObject.SetActive(false);
    }
}
