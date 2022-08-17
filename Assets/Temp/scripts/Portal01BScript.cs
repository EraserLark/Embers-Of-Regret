using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal01BScript : MonoBehaviour
{
    void OnCollisionEnter(Collision boxCollider)
    {
        // Ask Player1 to run the Portal01B method (in the PlayerBehaviourScript)
        boxCollider.gameObject.GetComponent<PlayerBehaviourScript>().Portal01B();

        // Plays the aucio clip
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();

    }
}
