using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;       //Uses UnityEngine.AI

//This is the one that works
public class MonsterFollow2 : MonoBehaviour
{
    //public GameObject monStand;
    //public GameObject monWalk;

    public static bool monsterMove;                  //If Monster should move (true=move, false=stop)
    public float startStopInterval = 1f;             //In seconds, how long the Monster will move for and pause for

    public Transform playerTransform;                //Ref to Player's transform
    public static Vector3 monsterTargetPosition;     //Var that stores the position the Monster will pursue (could be Player or Candle)

    public static bool candleLit = false;  //Set from 'CandleInteract', if false the monster will only track the Player's position. (If true, tracks candle)

    public NavMeshAgent agent;

    public AudioSource stepSFX;

    /*animation stuff
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //what is the distance
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        //is the distance smaller than #
        if(distance < 3)
        {
            //activate walk animation
            

        }

        //THIS WORK?? --Conner A
        if (agent.velocity != Vector3.zero)
        {
            //Animated moving
            anim.SetBool("walk", true);
        }
    }*/

    public AnimationControl animationControl;

    void Awake()
    {
        TimerStart();
    }

    //Starts the 'Timer' function, sets up monsterMove var starting out
    public void TimerStart()
    {
        monsterMove = true;  //Starts out 'true', so Monster will set destination first
        InvokeRepeating("Timer", startStopInterval, startStopInterval);   //Have both set to 'startStopInterval' to keep pacing of movements even
                                                                          //May want to have seperate times for moving/stopping, will need to rework another way!
    }

    //Alternates b/w moving Monster and stopping it, same amount of time for both Moving and Stopping currently (b/c using InvokeRepeating)
    public void Timer()
    {
        if (candleLit == false)
        {
            monsterTargetPosition = playerTransform.position;   //Var used for 'Setdestination', set to the player's position in this one moment
        }

        //monsterMove changes every ____ seconds since the function that sets it t/f is called by an 'InvokeRepeating' (Basically, a timer!)
        if (monsterMove == false)
        {
            NotMove();
            monsterMove = true;
            animationControl.walking = false;
        }
        else if (monsterMove == true)
        {
            Move();
            monsterMove = false;
            animationControl.walking = true;
        }
        //print("monsterMove parent = " + monsterMove);     //DEBUG
    }

    //Monster will move toward whatever position it's being fed
    public void Move()
    {
        //monStand.SetActive(false);
        //monWalk.SetActive(true);

        agent.SetDestination(monsterTargetPosition);    //Sets new destination for Monster to move toward
        agent.isStopped = false;                        //Allows agent (Monster) to start moving along path again
                                                        //print(monsterTargetPosition);                 //DEBUG
        //anim.SetBool("walk", true);
       
        stepSFX.Play(); //Play stepping sfx, may need to tweak timing
    }

    //Monster will stop moving
    public void NotMove()
    {
        //monStand.SetActive(true);
        //monWalk.SetActive(false);

        agent.isStopped = true;                         //Stops agent (Monster) where it's at on its path
        stepSFX.Stop(); //Stop playing stepping sfx, again may need to tweak timing
    }

    //2 below for use when reading note, pauses/unpasuses monster
    public void FreezeMon()
    {
        CancelInvoke("Timer");
        agent.velocity = Vector3.zero;
        agent.isStopped = true;
    }

    public void UnFreezeMon()
    {
        InvokeRepeating("Timer", startStopInterval, startStopInterval);
        agent.isStopped = false;
    }

    public void IncreaseSpeed()
    {
        agent.speed += 3;       //Used when player uses a key on a lock (progression), will speed up monster a set amount each time
    }

    /*
     * Obsolete, used when pausing game (not totally perfect but mostly worked)
    
    public void PauseMonster()      //Runs when game is paused, stops monster
    {
        CancelInvoke("Timer");
        agent.velocity = Vector3.zero;      //Stops monster in place
        //agent.isStopped = true;
        //Works!!!!
        //Add var that loops as a 2 sec timer (or howewver long startStopInterval is) so that when unpausing, can set that as the first 
    }
    
    public void ResumeMonster()     //Runs when game is unpaused
    {
        InvokeRepeating("Timer", startStopInterval, startStopInterval);
        agent.isStopped = false;
    }
    */
}
