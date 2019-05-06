using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    private bool willLeave = false;
    private int randomWillLeave;

    private bool isAngry = false;
    private bool isPunk = false;

    public int secondsBeingWaiting = 0;

    public int wrathTime = 100;

    public int wrathIndex = 0;
    public int wrathLimit = 10;

    public int burgerEated = 0;
    public int burgerLimit = 10;

    public int life = 100;
    public int AttackValue = 1;

    public void OnEnable()
    {
        randomWillLeave = Random.Range(0, 1);
        if (randomWillLeave >= 1)
        {
            willLeave = true;
        }
        if (randomWillLeave <= 0)
        {
            willLeave = false;
        }

        if (willLeave)
        {
            burgerEated = 0;
            burgerLimit = Random.Range(1, 10);
        }


        // Sera a déterminé au hasard
        isAngry = false;
        isPunk = false;
        wrathTime = Random.Range(20,120);
        wrathIndex = 0;
        wrathLimit = 0;




        secondsBeingWaiting = 0;
        burgerEated = 0;
    }

    void Update()
    {
        LifeCheck();

        if (willLeave)
        {
            if(burgerEated >= burgerLimit)
            {
                gameObject.GetComponent<TakePlace>().needToLeave = true;
                //Il part et reviens dans le pool.
            }
        }

        if (secondsBeingWaiting >= wrathTime)
        {
            isAngry = true; // Il s'impatiente et devient en colère => Prochaine étape le cassage.
        }

        if (wrathIndex >= wrathLimit)
        {
            isPunk = true; // Il attaque le FT => Need to be killed.
        }

        if (isPunk)
        {
            //Ici il attack le FT
            FuelStock.staticFuelStock.fuel -= AttackValue * Time.deltaTime;
        }


    }

    private void LifeCheck()
    {
        if (life <= 0)
        {
            gameObject.GetComponent<TakePlace>().Die(); // A changer pour qu'il "meurt", reparte dans le pool et puisse revenir plus tard avec différent settings.
        }
    }
}
