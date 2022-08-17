using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;       //Uses UnityEngine.AI

public class MonsterFollow1 : MonoBehaviour
{
    /*
    public GameObject player;
    public Transform playerTransform;

    public NavMeshAgent agent;

    IEnumerator currentChaseCoroutine;

    void Awake()
    {
        //Get Player Position
        //InvokeRepeating //Function that gets player position every few seconds
        InvokeRepeating("Chase", 1, 2);
    }

    /*
    void Update()
    {
        if(transform.position != playerTransform.position)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
    

    void Chase()
    {
        agent.SetDestination(playerTransform.position);
    }

    /*
    void Update()
    {
        if(transform.position != playerTransform.position)
        {
            if(currentChaseCoroutine != null)
            {
                StopCoroutine(currentChaseCoroutine);
            }

            currentChaseCoroutine = Chase(playerTransform.position);
            StartCoroutine(currentChaseCoroutine);
        }
    }

    IEnumerator Chase(Vector3 playerLocation)
    {
        while (transform.position != playerLocation)
        {
            agent.SetDestination(playerLocation);
            yield return null;
        }
    }
    */
}
