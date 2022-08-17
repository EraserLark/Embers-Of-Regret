using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Ask Player1 to run the PlayerRespawn02 method (in the PlayerBehaviourScript)
            other.gameObject.GetComponent<PlayerBehaviourScript>().PlayerRespawn02();
        }

        else
        {
            //Destroy it!
            Destroy(other.gameObject);
           // Debug.Log("destroyed");
        }
    }
}
