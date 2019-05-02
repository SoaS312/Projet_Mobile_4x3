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

    void Update()
    {
        Die();

        if (willLeave)
        {
            if(burgerEated >= burgerLimit)
            {
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

    private void Die()
    {
        if (life <= 0)
        {
            Destroy(gameObject); // A changer pour qu'il "meurt", reparte dans le pool et puisse revenir plus tard avec différent settings.
        }
    }
}
