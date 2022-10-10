using System.Collections;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{
    //RAYCASTING
    //Ray is based on camera position and direction
    public Camera gameCamera;
    RaycastHit hitInfo;

    //MOVEMENT
    public float flySpeed = 40;             
    public IEnumerator currentMoveCoroutine;       

    //ITEMS
    public static int playerItemNumber;        //Have to do with Player holding an item, will want to clean
    public static bool playerHoldingItem;

    private void Start()
    {
        playerItemNumber = 0;       //Player's hand starts out empty
        playerHoldingItem = false;
    }

    void Update()
    {
        //Left Click
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo))
            {
                Interact(hitInfo.transform, hitInfo.transform.tag);    //Determines the action performed based on the object's tag
                ObjectInteractable target = hitInfo.transform.gameObject.GetComponent<ObjectInteractable>();    //Avoids error if raycast hits obj with no "ObjectInteractable" script/inhereted class

                if (target != null)
                {
                    target.Selected();  //This is the primary interaction
                }
            }
        }

        //Right click
        if(Input.GetButtonDown("Fire2"))
        {
            if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hitInfo))
            {
                ObjectInteractable target = hitInfo.transform.gameObject.GetComponent<ObjectInteractable>();
                if (target != null)
                {
                    target.ItemSelected();  //Use item on obj
                }
            }
        }
    }

    void Interact(Transform objectHit, string tag)
    {
        if (tag == "Spot")      //Player will travel towards the selected 'Spot' in the room
        {
            StopCoroutine();

            currentMoveCoroutine = Move(objectHit.position, flySpeed);
            StartCoroutine(currentMoveCoroutine);
        }
    }

    public void StopCoroutine()
    {
        if (currentMoveCoroutine != null)     
        {
            StopCoroutine(currentMoveCoroutine);    //Avoids pulling player in two diff directions at the same time
        }
    }

    IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }
}
