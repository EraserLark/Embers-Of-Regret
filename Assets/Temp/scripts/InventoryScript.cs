using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{

    [Header("KEY COUNTER")]
    public Text keysText;                   // Reference to KeysText object
    public int keys = 0;                    // An integer for counting player deaths
    public bool enoughKeys = false;         // Bool to signal when player has enough keys
    public Color enoughKeysColour;          // To highlight key counter when enough keys reached
    public int keysNeeded = 1;              // Number of keys required to open the door

    [Header("LEGACY")]
    // public variables:
    public int cubes;
    public int glowingSpheres;


    private void Update()
    {
        // Keeps the death counter updated
        keysText.text = "" + keys;

        if (enoughKeys == true)
        {
            keysText.color = enoughKeysColour;
        }
    }

    // Handle cube pickups
    public void IncreaseCubeCount()
    {
        cubes++;

        // Runs the IncrementKeys method
        IncrementKeys();
    }

    // Handle glowing sphere pickups
    public void IncreaseSphereCount()
    {
        glowingSpheres++;

        // Runs the IncrementKeys method
        IncrementKeys();
    
    }

    void IncrementKeys()
    {
        // Adds +1 to value of 'keys'
        keys++;

        if (keys >= keysNeeded)
        {
            enoughKeys = true;

        }
    }
}
