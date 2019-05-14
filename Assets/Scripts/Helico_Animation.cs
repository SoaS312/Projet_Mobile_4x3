using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helico_Animation : MonoBehaviour
{
    public Animator anim;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
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
