using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronPuzzle : ItemInteractable  // ItemInteractable << ObjectInteractable << Monobehavior
{
    public int totalSecsCountdown = 12;     //Set in inspector, how many secs until cauldron restarts (12 to match with clock)
    int solutionCount = 0;      //Used in switch statement, increases when right ingredient added
    public GameObject clock;    //Reference to clock object that will be ticking down
    Transform clockHand;
    public AudioSource clockTick;
    Quaternion midnight;
    //GameObject pendulum;    //May not end up implementing if not time

    int countdown;  //What is counted down in the coroutine, set equal to 'totalSecsCountdown' though
    IEnumerator currentCountDownCoroutine;  //Var that stores current coroutine, for use in StopCoroutine()

    Renderer brewRenderer;  //Var needed to change color of brew                 
    public Light cauldonLight;  //color of light
    public GameObject smoke;

    public AudioClip incorrect;
    AudioSource brewSource;

    public GameObject purpleKey;

    public override void Awake()
    {
        base.Awake();

        keyItem = 0;    //Starting out, keyItem will be 0. Will change as puzzle progresses
        countdown = totalSecsCountdown;

        brewRenderer = GetComponent<Renderer>();
        //currentColor = Color.red;
        //ChangeColor(Color.red);

        clockHand = clock.transform.GetChild(1);
        midnight = clockHand.rotation;
        //pendulum = clock.transform.GetChild(2).gameObject;

        clockTick = clock.GetComponent<AudioSource>();
        brewSource = gameObject.GetComponent<AudioSource>();

        smoke.GetComponent<ParticleSystem>().Stop();
    }

    private void Update()
    {
        //If timer runs out
        if (countdown <= 0)
        {
            ResetCount();
            brewSource.PlayOneShot(incorrect);  //Play incorrect sound
            //smoke.SetActive(false);             //Stop smoke particles
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
                    //print("Correct, now blue!");    //DEBUG

                    //smoke.SetActive(true);      //Start smoke particle effects
                    smoke.GetComponent<ParticleSystem>().Play();
                    ChangeColor(Color.blue);
                    break;

                case 1:
                    //print("Correct, now green!");  //DEBUG

                    ChangeColor(Color.green);
                    break;

                case 2:
                    //print("Correct, now gold!");   //DEBUG

                    ChangeColor(Color.yellow);
                    break;

                case 3:
                    //print("Solved!!");              //DEBUG
                    //Play corrct cauldron sound
                    StopCoroutine(currentCountDownCoroutine);
                    ChangeColor(Color.magenta);

                    clockHand.rotation = midnight;  //Sets clock back to 12 (0 sec)
                    clock.GetComponent<AudioSource>().Stop();   //Stops Ticking Sound

                    gameObject.GetComponent<CapsuleCollider>().enabled = false; //Make it so cannot be interacted with further

                    purpleKey.SetActive(true);
                    break;
            }

            solutionCount++;
            keyItem++;

            brewSource.Play();

            correctItem = false;
        }
    }

    IEnumerator CountDown()
    {
        countdown = totalSecsCountdown;
        //clock.GetComponent<AudioSource>().Play();   //Play ticking sound, loops (Old way)

        while(countdown > 0)
        {
            countdown--;
            //print(countdown);       //DEBUG
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

        ChangeColor(Color.red);     //Set brew back to red
                                    //Play incorrct cauldron sound
        countdown = totalSecsCountdown;

        clock.GetComponent<AudioSource>().Stop();   //Stops Ticking Sound

        print("Restart!");      //DEBUG
    }

    void ChangeColor(Color color)       //Add second input for 'Emission color' if want
    {
        brewRenderer.material.SetColor("_Color", color);
        brewRenderer.material.SetColor("_EmissionColor", color);        //Changes emission color
        cauldonLight.color = color;
    }

    public override void Selected()
    {
        base.Selected();
        //Have like a cloud of smoke or something emerge, only aesthetic
    }
}
