using UnityEngine;
using UnityEngine.AI;

public class MonsterFollow2 : MonoBehaviour
{
    public static bool monsterMove;                  //If Monster should move (true=move, false=stop)
    public float startStopInterval = 1f;             //In seconds, how long the Monster will move for and pause for

    public Transform playerTransform;                
    public static Vector3 monsterTargetPosition;
    public NavMeshAgent agent;
    public static bool candleLit = false;  //If false, monster will track Player's position. (If true, tracks candle)

    public AudioSource stepSFX;
    public AnimationControl animationControl;

    void Awake()
    {
        TimerStart();
    }

    public void TimerStart()
    {
        monsterMove = true;  //Starts out 'true', so Monster will set destination first
        InvokeRepeating("Timer", startStopInterval, startStopInterval);   //Have both set to 'startStopInterval' to keep pacing of movements even
    }

    public void Timer()
    {
        if (!candleLit)
        {
            monsterTargetPosition = playerTransform.position;
        }

        if (!monsterMove)
        {
            NotMove();
            monsterMove = true;
            animationControl.walking = false;
        }
        else if (monsterMove)
        {
            Move();
            monsterMove = false;
            animationControl.walking = true;
        }
    }

    public void Move()
    {
        agent.SetDestination(monsterTargetPosition);
        agent.isStopped = false;
        stepSFX.Play();
    }

    public void NotMove()
    {
        agent.isStopped = true;
        stepSFX.Stop();
    }

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
        agent.speed += 3;
    }
}