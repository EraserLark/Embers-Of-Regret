using System.Collections;
using UnityEngine;

public class CauldronPuzzle : ItemInteractable  // ItemInteractable << ObjectInteractable << Monobehavior
{
    public int totalSecsCountdown = 12;     //How many secs until cauldron restarts (12 to match with clock)
    int solutionCount = 0;      //Used in switch statement for moving to next stage of puzzle
    public GameObject clock;
    Transform clockHand;
    public AudioSource clockTick;
    Quaternion midnight;

    int countdown;
    IEnumerator currentCountDownCoroutine;

    Renderer brewRenderer;                
    public Light cauldronLight;
    public GameObject smoke;

    public AudioClip incorrect;
    AudioSource brewSource;

    public GameObject purpleKey;

    public override void Awake()
    {
        base.Awake();

        keyItem = 0;    //Increases as puzzle progresses, each num corresponds to each ingredient for puzzle
        countdown = totalSecsCountdown;

        brewRenderer = GetComponent<Renderer>();
        brewSource = gameObject.GetComponent<AudioSource>();
        smoke.GetComponent<ParticleSystem>().Stop();

        clockHand = clock.transform.GetChild(1);
        midnight = clockHand.rotation;
        clockTick = clock.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (countdown <= 0)
        {
            ResetCount();
            brewSource.PlayOneShot(incorrect);
            smoke.GetComponent<ParticleSystem>().Stop();
        }
    }

    public override void ItemSelected()
    {
        base.ItemSelected();

        if(correctItem)
        {
            //Start/Refresh Timer
            if(currentCountDownCoroutine != null)
            {
                StopCoroutine(currentCountDownCoroutine);
                clockHand.rotation = midnight;
            }
            
            currentCountDownCoroutine = CountDown();
            StartCoroutine(currentCountDownCoroutine);

            switch (solutionCount)
            {
                case 0:
                    smoke.GetComponent<ParticleSystem>().Play();
                    ChangeColor(Color.blue);
                    break;

                case 1:
                    ChangeColor(Color.green);
                    break;

                case 2:
                    ChangeColor(Color.yellow);
                    break;

                case 3:
                    StopCoroutine(currentCountDownCoroutine);
                    ChangeColor(Color.magenta);

                    clockHand.rotation = midnight;  //Sets clock back to 12 (0 sec)
                    clock.GetComponent<AudioSource>().Stop();

                    gameObject.GetComponent<CapsuleCollider>().enabled = false; //Cannot be interacted with further

                    purpleKey.SetActive(true);
                    break;
            }

            solutionCount++;
            keyItem++;
            correctItem = false;

            brewSource.Play();
        }
    }

    IEnumerator CountDown()
    {
        countdown = totalSecsCountdown;

        while(countdown > 0)
        {
            countdown--;
            clockTick.Play();
            clockHand.eulerAngles += new Vector3(0, 0, 30);
            yield return new WaitForSeconds(1.5f);
        }
    }

    void ResetCount()
    {
        StopCoroutine(currentCountDownCoroutine);
        keyItem = 0;
        solutionCount = 0;
        countdown = totalSecsCountdown;

        ChangeColor(Color.red);
        clock.GetComponent<AudioSource>().Stop();
    }

    void ChangeColor(Color color)
    {
        brewRenderer.material.SetColor("_Color", color);
        brewRenderer.material.SetColor("_EmissionColor", color);
        cauldronLight.color = color;
    }

    public override void Selected()
    {
        base.Selected();
    }
}