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
    public int AttackValue = 5;

    public float AttackActualTimer;
    public float AttackMaxTimer = 3;

    public GameObject BulleStatut;
    public SpriteRenderer FeelingSprite;

    public List<Material> GuyMaterial;

    public float statusTime = 0;


    public Sprite Happy;
    public Sprite Angry;
    public Sprite Punk;

    public SkinnedMeshRenderer Skinning;
    public int materialIndex;

    public AudioClip FanDestroy;
    public AudioClip FanAttack;

    private AudioSource source;
    public Rigidbody caillou;

    void Awake()
    {
        source = GameObject.FindGameObjectWithTag("FoodTruck").GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        materialIndex = Random.Range(0, GuyMaterial.Count);
        Skinning.material = GuyMaterial[materialIndex];


        AttackMaxTimer = 3;
        AttackActualTimer = AttackMaxTimer;

        BulleStatut.SetActive(false);

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
            burgerLimit = Random.Range(1,1);
        }

        isAngry = false;
        isPunk = false;
        wrathTime = Random.Range(20,120);
        wrathIndex = 0;
        wrathLimit = Random.Range(1, 5);
        secondsBeingWaiting = 0;
        burgerEated = 0;
        //GetComponent<Renderer>().material = NormalMat;
    }

    void Update()
    {

        if (statusTime > 0)
        {
            statusTime -= Time.deltaTime; BulleStatut.SetActive(true);
        }

        if (statusTime <= 0)
        {
            statusTime = 0; BulleStatut.SetActive(false);
        }

        if (secondsBeingWaiting <= wrathTime)
        {
            secondsBeingWaiting += Time.deltaTime;
        }

        LifeCheck();

        if (willLeave)
        {
            if (burgerEated >= burgerLimit)
            {
                gameObject.GetComponent<TakePlace>().needToLeave = true;
                PlayerPrefs.SetInt("TotalFanSatisfied", PlayerPrefs.GetInt("TotalFanSatisfied") + 1);
            }
        }

        if (secondsBeingWaiting >= wrathTime)
        {
            isAngry = true; secondsBeingWaiting = 0; wrathIndex += 1; BeAngry(2f); LikesParticles.DislikesNumber += 1;
        }

        if (wrathIndex >= wrathLimit)
        {
            isPunk = true;
        }

        PunkAttack();

    }

    private void PunkAttack()
    {
        if (isPunk)
        {
            Debug.Log("I'm a punk");
            if (AttackActualTimer >= 0)
            {
                Debug.Log("Calculating");
                AttackActualTimer -= Time.deltaTime;
            }

            if (AttackActualTimer <= 0)
            {
                if (!PlayerPrefs.HasKey("Sound"))
                {
                    source.PlayOneShot(FanAttack, 1);
                }
                Debug.Log("Attacking");
                AttackActualTimer = AttackMaxTimer;
                FuelStock.staticFuelStock.fuel -= AttackValue;
                Instantiate(caillou, transform.position, Quaternion.identity);

                BePunk(1f);
            }
        }
    }

    public void BeHappy(float duration)
    {
        statusTime = duration;
        FeelingSprite.sprite = Happy;
    }

    public void BeAngry(float duration)
    {
        statusTime = duration;
        FeelingSprite.sprite = Angry;
    }

    public void BePunk(float duration)
    {
        statusTime = duration;
        FeelingSprite.sprite = Punk;
    }

    private void LifeCheck()
    {
        if (life <= 0)
        {
            FollowersManager.staticFollowersManager.actualFollowers.Remove(this.gameObject);
            if (!PlayerPrefs.HasKey("Sound"))
            {
                source.PlayOneShot(FanDestroy, 1);
            }
            gameObject.GetComponent<TakePlace>().Die();
            life = 1;
            PlayerPrefs.SetInt("TotalFanKicked", PlayerPrefs.GetInt("TotalFanKicked") + 1);
        }
    }
}
