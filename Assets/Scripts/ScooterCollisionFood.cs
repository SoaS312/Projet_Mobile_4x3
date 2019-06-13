using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ScooterCollisionFood : MonoBehaviour
{
    public bool isToxic;
    public int Toxicindex;

    public Transform spawnPos;

     public Mesh NonToxicMesh, ToxicMesh;
     //public Material NonToxicMaterial, ToxicMaterial;


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "FoodPrepScooter")
                {
                    gameObject.SetActive(false);
                    GetComponent<SplineWalker>().progress = 0;
                    transform.position = spawnPos.position;
                    Scooter.staticScooter.PrepFoodList.Add(gameObject);
                }

            }
        }
    }

    public void Start()
    {
        Toxicindex = Random.Range(0, 100);

        if (Toxicindex > 15)
        {
            GetComponent<MeshFilter>().mesh = NonToxicMesh;
            //GetComponent<MeshRenderer>().material = NonToxicMaterial;
        }
        else
        {
            isToxic = true;
            GetComponent<MeshFilter>().mesh = ToxicMesh;
            //GetComponent<MeshRenderer>().material = ToxicMaterial;
        }
        
        if (FoodTruckState.staticFoodTruckState.isScooterActive)
        {
            if (ScoreManager.money > Scooter.staticScooter.MoneyCost)
            ScoreManager.money -= Scooter.staticScooter.MoneyCost; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FoodTruck")
        {
            if (GetComponent<SplineWalker>().progress >= 0.7f)
            {
                if (!isToxic)
                {
                    FoodStock.staticFoodStock.food += Scooter.staticScooter.foodAmount;
                    //SpawnGameFeelIcons.staticSpawnGameFeelIcons.ForceFoodSpriteSpawn();
                }
                else if (isToxic)
                {
                    FoodStock.staticFoodStock.food -= Mathf.RoundToInt(Scooter.staticScooter.foodAmount/2);
                }
                GetComponent<SplineWalker>().progress = 0;
                Scooter.staticScooter.PrepFoodList.Add(gameObject);
                transform.position = spawnPos.position;
                gameObject.SetActive(false);
            }
        }
    }
}
