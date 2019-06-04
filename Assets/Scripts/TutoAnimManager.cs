using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoAnimManager : MonoBehaviour
{
    private Animator anim;
    public RuntimeAnimatorController CookAnimator;
    public RuntimeAnimatorController DriverAnimator;
    public RuntimeAnimatorController SellerAnimator;
    public RuntimeAnimatorController VigileAnimator;
    public RuntimeAnimatorController ScooterAnimator;
    public RuntimeAnimatorController FuelAnimator;
    
    public GameObject Fans;


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

    public void ClicVigile()
    {
        anim.SetTrigger("ClicVigile");
    }

    public void StopAnim()
    {
        anim.enabled = false;
    }
    public void DriverAnim()
    {
        anim.runtimeAnimatorController = DriverAnimator;
    }

    public void CookAnim()
    {
        anim.runtimeAnimatorController = CookAnimator;
    }

    public void SellerAnim()
    {
        anim.runtimeAnimatorController = SellerAnimator;
    }

    public void VigileAnim()
    {
        anim.runtimeAnimatorController = VigileAnimator;
    }
    public void ScooterAnim()
    {
        anim.runtimeAnimatorController = ScooterAnimator;
    }

    public void FuelAnim()
    {
        anim.runtimeAnimatorController = FuelAnimator;
    }


    public void ClicSeller()
    {
        anim.SetTrigger("ClicSeller");
    }

    public void ClicLivreur()
    {
        anim.SetTrigger("ClicLivreur");
    }

    public void ClicFuel()
    {
        anim.SetTrigger("ClicFuel");
    }

    public void EnableFan()
    {
        Fans.gameObject.SetActive(true);
    }

}
