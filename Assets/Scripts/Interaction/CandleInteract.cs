using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleInteract : CandleManager    // CandleManager << ObjectInteractable << Monobehavior
{
    public GameObject flame;
    AudioSource candleSource;   //Contains the 'Candle Extinguish' sfx

    Transform candleTransform;      //Var that will hold the transform of the candle

    public override void Awake()
    {
        base.Awake(); //creates player var, stores the gameObject of the Player (Don't need?)
        flame = gameObject.transform.GetChild(0).gameObject;    //Do I even need this? Could prob set this in inspector, and will continue to work if make candle a prefab
        candleTransform = gameObject.transform;                 //Set var to the transform of this candle
        candleSource = gameObject.GetComponent<AudioSource>();
    }

    //Runs when clicked on
    public override void Selected()
    {
        if(!fuelUsedUp) //If the player has recharged, not lit a candle recently (see CandleManager for details)
        {
            //base.Selected();        //Changes 'state' to T/F each time clicked on
            state = true;

            flame.SetActive(state);     //If state = true, flame turns on. If state = false, flame goes out.
            MonsterFollow2.candleLit = state;         //Determines if monster will track player's position(false) or candle(true)
                                                      //May need to move to bottom of this method? (Works rn at least)
            fuelUsedUp = state;         //T, Player cannot light another candle

            float flameTimer = Random.Range(3.0f, 10.0f);     //Var that holds the number of seconds (Random from range) until the candle extinguishes after it has been lit
                                                              //Set to int instead, for cleaner numbers, more predicatabiity??
            MonsterFollow2.monsterTargetPosition = candleTransform.position;       //Sets monster to track candle's position now
            Invoke("Extinguish", flameTimer);   //Will extinguish the candle after it has been lit, after a set amount of random seconds (determined above)
                                                //print(flameTimer);      //DEBUG

            //UsedFuel();
        }
        else
        {
            print("Out of fuel");
            //Find way to visually show this in game/UI?
            candleSource.Play();   //Play extinguish for now
        }

        //Getting rid of manual extinguishing maybe for the sake of efficiency
        /*
        if(!state)     //If not active (F; flame off)
        {
            CancelInvoke("Extinguish");
        }
        */
        
    }

    //Puts out the candle
    void Extinguish()
    {
        state = false;
        flame.SetActive(state);
        MonsterFollow2.candleLit = state;   //Determines if monster will track player's position(false) or candle(true)
        fuelUsedUp = state;                 //F, Player can light another candle

        candleSource.Play();   //Play extinguish sfx

        //print("gone out");      //DEBUG
        //Play sound as well?
    }
}
