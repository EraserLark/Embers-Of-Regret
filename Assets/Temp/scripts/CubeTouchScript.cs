using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTouchScript : MonoBehaviour
{
    // This runs as soon as the game begins
    void Start()
    {
        // Testing the script
        // Debug.Log("Hello World!");
    }

    // This runs if something collides with the cube's boxCollider component
    void OnCollisionEnter(Collision boxCollider)
    {
        // Tells us that something has touched the box
        // Debug.Log("Ouch!");

        if (boxCollider.gameObject.tag == "Player")
        {

            // This changes the colour of the cube
            // gameObject.GetComponent<Renderer>().material.color = Color.red;

            // This removes the cube from the game
            Destroy(gameObject);

            // Reports when the cube is touched by the Player
            Debug.Log("Cube picked up by " + boxCollider.gameObject.name);

            // Make Player1 increase the cube count by +1
            // boxCollider.gameObject.GetComponent<InventoryScript>().cubes++;

            // Ask Player1 to run the cube-counting method
            boxCollider.gameObject.GetComponent<InventoryScript>().IncreaseCubeCount();
        }
    }
}
