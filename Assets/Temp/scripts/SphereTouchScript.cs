using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTouchScript : MonoBehaviour
{
    // This runs as soon as the game begins
    void Start()
    {
        // Testing the script
        // Debug.Log("Hello World!");
    }

    // This runs if something collides with the sphere's boxCollider component
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // This removes the cube from the game
            Destroy(gameObject);

            // Ask Player1 to run the cube-counting method
            other.gameObject.GetComponent<InventoryScript>().IncreaseSphereCount();
        }
    }
}
