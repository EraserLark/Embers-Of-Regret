using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMakerScript : MonoBehaviour
{
    // public references:
    public GameObject boxToSpawn;
    public Transform whereToSpawn;
    public float timeBetweenBoxes = 2.5f;

    //private variables:
    float timer;
    public bool makeBoxes = true;


    // Update is called once per frame
    void Update()
    {
        // If makeBozes is true..
        if (makeBoxes == true)
        {
            // add the current game time to the value of 'timer'
            timer += Time.deltaTime;

            // If the value of 'timer' is greater than the specified time between boxes..
            if (timer >= timeBetweenBoxes)
            {
                // .. spawn a box at the given location (ie. 'whereToSpawn' reference)
                Instantiate(boxToSpawn, whereToSpawn.position, whereToSpawn.rotation);

                // This resets the timer
                timer = 0f;
            }
        }
    }

    // Toggles box-making
    public void toggleMakeBoxes()
    {
         makeBoxes = !makeBoxes;
    }

}
