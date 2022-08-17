using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run2 : MonoBehaviour
{
    //what is the player
    public GameObject Player;
    //Run when player is this close
    public float EnemyDistanceRun = 7.0f;

    //speed and bait to flower
    public Transform Flower;

    //look at what. It's the if statement later.
    public bool look;

    //how fast to move.
    int MoveSpeed = 5;

    //when does it sense you
    int MaxDist = 10;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);


        //run from player
        if (distance < EnemyDistanceRun)
        {
            // look away from the player
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            // run in a direction that adds distance
            Vector3 newPos = transform.position + dirToPlayer;

            //start moving to new position
            //_agent.SetDestination(newPos);
            //moving to new position
            transform.position -= transform.position * MoveSpeed * Time.deltaTime;
        }

        //If player is far enough away look at flower
        if (look)
        {
            transform.LookAt(Flower);
        }


        //if the player is further than the max distance, then look at the flower and go to it.
        if (Vector3.Distance(transform.position, Player.transform.position) >= MaxDist)
        {
            //This helped with moving faster so you can't catch the fairy
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            //look at the flower
            look = true;

            //If the player is close don't look at the flower
            if (Vector3.Distance(transform.position, Player.transform.position) <= MaxDist)
            {
                // look anywhere
                look = false;
            }
        }
    }
}
