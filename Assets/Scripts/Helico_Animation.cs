using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helico_Animation : MonoBehaviour
{
    public Animator anim;
    public bool isActive;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void HelicoTrue()
    {
        anim.SetBool("switch", true);
    }

    public void HelicoFalse()
    {
        anim.SetBool("switch", false);
    }
}
