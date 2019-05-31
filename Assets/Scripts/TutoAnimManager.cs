using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoAnimManager : MonoBehaviour
{
    private Animator anim;
    public RuntimeAnimatorController CookAnimator;
    public RuntimeAnimatorController SellerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

    public void CookAnim()
    {
        anim.runtimeAnimatorController = CookAnimator;
    }

    public void SellerAnim()
    {
        anim.runtimeAnimatorController = SellerAnimator;
    }

}
