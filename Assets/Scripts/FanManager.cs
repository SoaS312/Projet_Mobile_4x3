using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    public bool willLeave = false;
    private int randomWillLeave;

    public bool isAngry = false;
    public bool isPunk = false;

    public float secondsBeingWaiting = 0;

    public int wrathTime = 100;

    public int wrathIndex = 0;
    public int wrathLimit = 10;

    public int burgerEated = 0;
    public int burgerLimit = 10;

    public int life = 100;
    public int AttackValue = 1;

    public float AttackActualTimer;
    public float AttackMaxTimer;



    public Material NormalMat;
    public Material AngryMat;
    public Material PunkMat;

    public void OnEnable()
    {

        randomWillLeave = Random.Range(0, 100);
        if (randomWillLeave >= 30)
        {
            willLeave = true;
        }
        if (randomWillLeave <= 0)
        {
            willLeave = false;
        }

        if (willLeave)
        {
            burgerLimit = Random.Range(1, 10);
        }

        isAngry = false;
        isPunk = false;
        wrathTime = Random.Range(20,120);
        wrathIndex = 0;
        wrathLimit = Random.Range(1, 5);
        secondsBeingWaiting = 0;
        burgerEated = 0;
        GetComponent<Renderer>().material = NormalMat;
    }

    void Update()
    {

        if (secondsBeingWaiting <= wrathTime)
        {
            secondsBeingWaiting += Time.deltaTime;
        }

        LifeCheck();

        if (willLeave)
        {
            if(burgerEated >= burgerLimit)
            {
                gameObject.GetComponent<TakePlace>().needToLeave = true;
            }
        }

        if (secondsBeingWaiting >= wrathTime)
        {
            GetComponent<Renderer>().material = AngryMat;
            isAngry = true;
            secondsBeingWaiting = 0;
            wrathIndex += 1;
        }

        if (wrathIndex >= wrathLimit)
        {
            isPunk = true;
        }

        if (isPunk)
        {
            GetComponent<Renderer>().material = PunkMat;

            if (AttackActualTimer >= AttackMaxTimer)
            {
                AttackActualTimer -= Time.deltaTime;
            }

            if (AttackActualTimer <= 0)
            {
                AttackActualTimer = AttackMaxTimer;
                FuelStock.staticFuelStock.fuel -= AttackValue * Time.deltaTime;
            }
        }


    }

    private void LifeCheck()
    {
        if (life <= 0)
        {
            gameObject.GetComponent<TakePlace>().Die(); 
        }
    }
}
