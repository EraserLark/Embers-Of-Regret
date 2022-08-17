using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnScript01 : MonoBehaviour
{
    // This is called when the game begins
    void Start()
    {
        // Debug.Log("KillZone is online");
    }

    // Called when a collision event occurs
    void OnCollisionEnter(Collision boxCollider)
    {
        if (boxCollider.gameObject.tag == "Player")
        {
            // Reports what triggered the event
            // Debug.Log("KillZone was triggered by " +boxCollider.gameObject.name);

            // Ask Player1 to run the PlayerRespawn01 method (in the PlayerBehaviourScript)
            boxCollider.gameObject.GetComponent<PlayerBehaviourScript>().PlayerRespawn01();
        }
    }
}
