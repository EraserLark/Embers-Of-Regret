using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RAY IS BASED ON CAMERA POSITION/DIRECTION
//When player clicks, will shoot raycast, then determine what action to perform based on the object that is clicked on (hit by raycast)
public class MouseInteract : MonoBehaviour
{
    /* Tutorials:
    https://youtu.be/fFq5So-UB0E - SebLague Raycast
    https://www.youtube.com/watch?v=THnivyG0Mvo - Brackeys Raycast
    https://www.youtube.com/watch?v=iUeNteddnsw - For Crosshair change
    https://youtu.be/Eq6rCCO2EU0 - Coroutines
    */

    //RAYCASTING
    public Camera gameCamera;               //Reference to camera
    RaycastHit hitInfo;                     //Variable that stores info about the raycast collision / object ray collides with

    //MOVEMENT
    public float flySpeed = 40;             //Speed at which player moves from one spot to another
    public IEnumerator currentMoveCoroutine;       //Stores the current coroutine of 'Move' running, for use in 'StopCoroutine'

    //ITEMS
    public static int playerItemNumber;        //Have to do with Player holding an item, will want to clean
    public static bool playerHoldingItem;

    private void Start()
    {
        //Rework??
        playerItemNumber = 0;     //Hand empty?
        playerHoldingItem = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))   //Checks if Player has clicked the Left Mouse Button
        {
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo))
            //Checks if, after a ray has been shot out from the Camera's position, moving in the Camera's 'Forward' direction (blue arrow),
            //it collides with something (that something will be stored in 'hitInfo'). Returns true if ray collides with something.
            {
                Interact(hitInfo.transform, hitInfo.transform.tag);    //Function that will determine the action to be performed based on the selected object's traits
                                                                       //Takes in the hit object's transform, and tag
                ObjectInteractable target = hitInfo.transform.gameObject.GetComponent<ObjectInteractable>();    //Avoids error if raycast hits obj with no "ObjectInteractable" script/inhereted class
                if (target != null)     //If obj has the 'ObjectInteractable' class in some form...
                {
                    target.Selected();  //Runs "Selected" function in the target (THIS is the primary interaction)
                }
            }
        }

        //Right click will be used for interacting using Items on objs...
        if(Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo))
            //Checks if, after a ray has been shot out from the Camera's position, moving in the Camera's 'Forward' direction (blue arrow),
            //it collides with something (that something will be stored in 'hitInfo'). Returns true if ray collides with something.
            {
                ObjectInteractable target = hitInfo.transform.gameObject.GetComponent<ObjectInteractable>();    //Avoids error if raycast hits obj with no "ObjectInteractable" script/inhereted class
                if (target != null)     //If obj has the 'ObjectInteractable' class in some form...
                {
                    target.ItemSelected();  //Runs "ItemSelected" function in the target (Use item on obj)
                }
            }
        }
        //Also add option for holding mouse button down for set amount of time (okay if no time before 3/12 at least)
    }

    void Interact(Transform objectHit, string tag)     //Function that will determine the action the Player performs based on the selected object's traits
    {
        //Debug.Log(objectHit.name);  //DEBUG: Displays name of object hit by Ray in the console window

        if (tag == "Spot")      //Player will travel over to a 'Spot' if Player clicked on corresponding hitbox/object
        {
            StopCoroutine();

            currentMoveCoroutine = Move(objectHit.position, flySpeed);      //Vec3 destination, Float speed
            StartCoroutine(currentMoveCoroutine);                           //Starts 'Move' coroutine (Below)

            //objectHit.GetComponent<Collider>().enabled = false;   //Disable this from the coll box side instead?
        }
        else if(tag == "Item")      //If left click on an obj tagged 'item'
        {
            //playerItemNum = objectHit.GetComponent<ItemInteractTest>().itemNum;     //Set the player's item number same as that
            //print(playerItemNum);
            //playerHoldingItem = true;
        }
    }

    public void StopCoroutine()
    {
        if (currentMoveCoroutine != null)           //If there is a 'Move' coroutine already running... (Player is currently in the process of moving to anoter spot)
        {
            StopCoroutine(currentMoveCoroutine);    //Stops current 'Move' coroutine that is running before starting a new one, avoids pulling player in diff directions.
        }
    }

    IEnumerator Move(Vector3 destination, float speed)  //Takes in a destination and speed, moves object from current position to destination using that speed
    {
        while (transform.position != destination)   //This will loop until the Player reaches the destination (B/c Coroutine though, can pause/start this to occur over time)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);  //Moves Player
            yield return null;  //Pauses coroutine, won't come back until next frame (Without this the movement will happen in one frame, loop will finish before moving forward)
        }
    }
}
