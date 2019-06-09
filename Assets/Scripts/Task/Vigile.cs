using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vigile : MonoBehaviour
{    
    public int attackValue;
    public CrewUpgradeScriptable VigileLevel;

    private AudioSource source;

    public AudioClip[] Fights;
    private AudioClip PlayedFight;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        attackValue = VigileLevel.CrewUpgradeList[VigileLevel.CrewLevelIndex];
    }

    void Update()
    {
        Kicking();
    }

    private void Kicking()
    {
        if (FoodTruckState.staticFoodTruckState.isVigileActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Followers")
                    {
                        int index = Random.Range(0, Fights.Length);
                        PlayedFight = Fights[index];
                        source.PlayOneShot(PlayedFight, 1);
                        hit.transform.GetComponent<FanManager>().life -= attackValue;
                    }

                }
            }
        }
    }
}
