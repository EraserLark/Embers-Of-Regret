using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    public bool state = false;
    public GameObject player;
    //public static int playersItemNum = -1;
    public bool itemInteractable = false;       //Set in inspector specifically for objs that will have item interactability!!
    public PlayerInventory playerInventory;     //Reference to PlayerInventory script, avoid having two seperate int variables tracking the player's item num

    public virtual void Awake()
    {
        //Can maybe create an item parent class, put this in there?? (Might need for all interactable items tho)
        player = GameObject.FindGameObjectWithTag("Player");
        //print(gameObject.name + "has found the player");        //DEBUG

        playerInventory = player.GetComponent<PlayerInventory>();
    }

    public virtual void Selected()  //Declare 'virtual' to allow to be overridden
    {
        state = !state;
        //print(gameObject.name + "'s object state is now: " + state);      //DEBUG
    }

    public virtual void ItemSelected()       //Right click
    {
        /*
        if (itemInteractable)
        {
            //playersItemNum = player.GetComponent<PlayerInventory>().playerItemNum;
            //print("Interacting on this obj with item#: " + playersItemNum);
        }
        */
        if (!itemInteractable)
        {
            print("You can't use an item on this!");        //Overload this in objs where you want an item to work! (Remove base.ItemSelected!)
        }
    }
}
