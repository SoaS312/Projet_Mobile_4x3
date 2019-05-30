using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoAnimManager : MonoBehaviour
{
    private Animator anim;
    public RuntimeAnimatorController CookAnimator;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.runtimeAnimatorController = CookAnimator;
    }

    public void ClicDriver()
    {
        anim.SetTrigger("ClicDriver");
    }

    public void ClicCook()
    {
        anim.SetTrigger("ClicCook");
    }

    public void StopAnim()
    {
        anim.enabled = false;
    }

}
