using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animVigile : MonoBehaviour
{
    public GameObject startposition;
    public bool isAttacking = false;
    private Animator anim;
    public Vector3 fanposition;
    [Range(0.00001f, 1f)]
    public float speed;

    private void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Kicking();
        }

        if (!isAttacking)
        {
            transform.position = Vector3.Lerp(transform.position, startposition.transform.position, speed*Time.deltaTime*10);
        }

        if (isAttacking)
        {
            //StartCoroutine(GoFightCheh());
            transform.position = Vector3.Lerp(transform.position, fanposition, speed*Time.deltaTime*10);
            Debug.Log("fdp");
            StartCoroutine(GoTruckCheh());
        }
        
    }

    private void Kicking()
    {
        if (FoodTruckState.staticFoodTruckState.isVigileActive)
        {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if ((hit.transform.gameObject.tag == "Followers"))
                    {

                    anim.SetBool("Attack", true);
                    //isAttacking = true;
                    fanposition = hit.transform.position + new Vector3(1f, 0, 0);
                    }


                }
        }
    }
    public void LerpAttack()
    {
        isAttacking = true;
    }

    public void GoTruck()
    { 
        isAttacking = false;
    }

    IEnumerator GoTruckCheh()
    {
        yield return new WaitForSeconds(1);
        isAttacking = false;
        anim.SetBool("Attack", false);
    }
    IEnumerator GoFightCheh()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
    }
}