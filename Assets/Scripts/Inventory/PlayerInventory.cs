using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int playerItemNum;
    public GameObject playerHand;               //Reference to the PlayerHand obj that is a child of the Main Camera, where in space items are 'held'
    public GameObject droppedItemToRestore;     //Stores gameobject that is clicked on to hold an item, will use later when dropping item to have this reappear

    AudioSource playerSource;
    public AudioClip grabItem;

    private void Awake()
    {
        playerItemNum = -1;     //Player's hand is empty at start

        playerSource = gameObject.GetComponent<AudioSource>();
    }

    public void HoldItem(int itemNum, GameObject itemToRestore)
    {
        if(playerItemNum == -1)  //Player's hand is empty
        {
            playerItemNum = itemNum;
            droppedItemToRestore = itemToRestore;
            playerHand.transform.GetChild(playerItemNum).gameObject.SetActive(true);
            playerSource.PlayOneShot(grabItem);
        }
        else
        {
            print("You're already holding " + playerItemNum);       //DEBUG
        }

        /*
        //For holding mini item in hand
        switch (playerItemNum)
        {
            case 1:
                print(playerItemNum);
                break;
            case 2:
                print("Number 2!");
                break;
            default:
                print("You have no item");
                break;
        }
        */
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(playerItemNum != -1)     //If player is holding an item
            {
                DropItem();
            }
            else
            {
                print("Noting to drop!");       //DEBUG
            }
        }
    }

    void DropItem()
    {
        GameObject dropObject;
        Vector3 playerHandPos = new Vector3();

        dropObject = playerHand.transform.GetChild(playerItemNum).gameObject;
        playerHandPos = playerHand.transform.position;

        //Instantiate item corresponding that drops
        dropObject = Instantiate(dropObject, playerHandPos, Quaternion.identity);
        dropObject.GetComponent<Rigidbody>().isKinematic = false;
        //Then start a function in that dropped Object to have it 'warp' back to its og spot, pass in saved item 
        dropObject.GetComponent<DropObject>().StartInvoke(droppedItemToRestore);    //Pass in prev picked up item

        //Have obj in player's hand dissapear at the same time
        playerHand.transform.GetChild(playerItemNum).gameObject.SetActive(false);

        playerItemNum = -1;       //Hand is empty again
    }
}
