using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{ 

    // This runs as soon as the game begins
    void Start()
    {
        //gameObject.SetActive(false);
        // Testing the script
        // Debug.Log("Hello World!");
    }

    // This runs if something collides with the cube's boxCollider component
    void OnCollisionEnter(Collision boxCollider)
    {
        // Tells us that something has touched the box
        // Debug.Log("Ouch!");

        if (boxCollider.gameObject.tag == "Barrier")
        {

            //gameObject.SetActive(true);
            // This changes the colour of the cube
            //gameObject.GetComponent<Renderer>().material.color = Color.red;

            //Attempts to make an object appear
           // gameObject.tag == "BridgeAppear" SetActive(true);
            //GameObject.SetActive.BridgeAppear;

                // Reports when the cube is touched by the Player
                //Debug.Log("Cube picked up by " + boxCollider.gameObject.name);
        }
    }
}
