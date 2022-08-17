using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourScript : MonoBehaviour
{
    [Header("SPAWN POINTS")]
    public Transform spawnPoint01;              // Location of SpawnPoint (Empty GameObject)
    public Transform spawnPoint02;              // Location of SpawnPoint (Empty GameObject)

    [Header("PORTALS")]
    public Transform portalA;                   // Target location of Portal A
    public Transform portalB;                   // Target location of Portal B

    [Header("Desert")]
    public Transform portalC;                   // Target location of Portal c
    public Transform portalD;                   // Target location of Portal d


    public void PlayerRespawn01()
    {
        // This matches Player1's position with that of SpawnPoint01
        gameObject.transform.position = spawnPoint01.transform.position;

        // This zeroes the player's velocity
        GetComponent<Rigidbody>().velocity = Vector3.zero;


    }

    public void PlayerRespawn02()
    {
        // This matches Player1's position with that of SpawnPoint01
        gameObject.transform.position = spawnPoint02.transform.position;

        // This zeroes the player's velocity
        GetComponent<Rigidbody>().velocity = Vector3.zero;

   
    }

    public void Portal01A()
    {
        // This matches Player1's position with that of PortalB
        gameObject.transform.position = portalB.transform.position;
        
    }


    public void Portal01B()
    {
        // This matches Player1's position with that of PortalB
        gameObject.transform.position = portalA.transform.position;
        
    }

    public void Portal01C()
    {
        // This matches Player1's position with that of PortalB
        gameObject.transform.position = portalD.transform.position;

    }


    public void Portal01D()
    {
        // This matches Player1's position with that of PortalB
        gameObject.transform.position = portalC.transform.position;

    }


}
