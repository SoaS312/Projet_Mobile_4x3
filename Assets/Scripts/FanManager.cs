using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanManager : MonoBehaviour
{
    public bool willLeave = false;

    public bool isAngry = false;
    public bool isPunk = false;

    public int secondsBeingWaiting = 0;

    public int wrathTime = 100;

    public int wrathIndex = 0;
    public int wrathLimit = 10;

    public int burgerEated = 0;
    public int burgerLimit = 10;

    public int life = 100;

    public void OnEnable()
    {
        // Sera a déterminé au hasard
        willLeave = false;
        isAngry = false;
        isPunk = false;
        secondsBeingWaiting = 0;
        wrathTime = 100;
        wrathIndex = 0;
        wrathLimit = 0;
        burgerEated = 0;
        burgerLimit = 10;
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


    }

    private void LifeCheck()
    {
        if (life <= 0)
        {
            gameObject.GetComponent<TakePlace>().Die(); // A changer pour qu'il "meurt", reparte dans le pool et puisse revenir plus tard avec différent settings.
        }
    }
}
