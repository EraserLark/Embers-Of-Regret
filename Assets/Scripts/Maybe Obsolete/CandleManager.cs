using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : ObjectInteractable  //  ObjectInteractable << Monobehavior
{
    public static bool fuelUsedUp;     //Make static?
    float rechargeTime = 12f;

    public AudioClip flameRecharge;
    public AudioSource playerSource;    //Player's audio source, for playing recharged sound

    public override void Awake()
    {
        base.Awake();  //creates player var, stores the gameObject of the Player (Don't need?)
        fuelUsedUp = false;

        playerSource = player.GetComponent<AudioSource>();
    }

    /*
    public void UsedFuel()
    {
        fuelUsedUp = true;
        Invoke("Recharged", rechargeTime);
    }

    void Recharged()
    {
        fuelUsedUp = false;
        playerSource.clip = flameRecharge;
        playerSource.PlayOneShot(flameRecharge, 0.15f);    //Player will hear flame recharge sound once recharged
        //print("Recharged");     //DEBUG
    }
    */
}
