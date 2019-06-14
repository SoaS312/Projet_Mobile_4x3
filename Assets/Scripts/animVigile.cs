using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animVigile : MonoBehaviour
{
    public GameObject startposition;
    public bool isAttacking = false;
    private Animator anim;
    public Vector3 fanposition;
    public GameObject Baston;
    [Range(0.00001f, 1f)]
    public float speed;
    public GameObject Mesh;
    public SkinnedMeshRenderer Salope;
    public bool canAttack;
    //public bool CanSpawn;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //Salope = Mesh.GetComponent<MeshRenderer>();
        //CanSpawn = false;
        fanposition = new Vector3(100, 100, 100);
        canAttack = true;
    }

    void Update()
    {

        if ((Input.GetMouseButtonDown(0)) && canAttack && !isAttacking)
        {
            
            Kicking();

        }

        if (!isAttacking)
        {
            transform.position = Vector3.Lerp(transform.position, startposition.transform.position, speed*Time.deltaTime*10);
            canAttack = true;
        }

        if ((isAttacking) && (canAttack))// && (transform.position == startposition.transform.position))
        {
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

                    StartCoroutine(GoFightCheh());
                    //isAttacking = true;
                    fanposition = hit.transform.position + new Vector3(1f, 0, 0);

                    ParticleBaston();
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
        
        yield return new WaitForSeconds(0.5f);
        //Mesh.SetActive(false);
        Salope.enabled = false;
        yield return new WaitForSeconds(2);
        //Mesh.SetActive(true);
        Salope.enabled = true;
        isAttacking = false;
        anim.SetBool("Attack", false);
        canAttack = false;


    }
    IEnumerator GoFightCheh()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(1f);
    }

    public void ParticleBaston()
    {
        Baston.transform.position = fanposition + new Vector3(-1f, 1, 0);
        Baston.SetActive(true);
        StartCoroutine(WaitForPS());
    }
    IEnumerator WaitForPS()
    {
        yield return new WaitForSeconds(3);
        Baston.SetActive(false);
    }
}