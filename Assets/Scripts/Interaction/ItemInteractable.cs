using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : ObjectInteractable
{
    public bool correctItem = false;     //Use in children scripts to perform specific functions if true
    public int keyItem = 0;      //Set in inspector   
    //This number corresponds to the itemNum of the item that correctly interacts with this obj, playersItemNum must be equal to this in order to accept
    public Transform playerHandT;

    public override void Awake()
    {
        base.Awake();

        playerHandT = player.transform.GetChild(0).transform.GetChild(0).transform; //Need for everey interactable obj?? Might be more efficient just to include in 'ItemInteractable' objs
        //print(gameObject.name + "has found the playerHandT");        //DEBUG
    }

    public override void ItemSelected()
    {
        base.ItemSelected();    //Just "if !itemInteractable" the game will note 'you can't use an item on this' (IDK if necessary, but barely any extra code for rn)

        if (playerInventory.playerItemNum == keyItem)     //If player is holding correct item to interact with this
        {
            //Destroy(gameObject);    //The interacted with obj disappears

            correctItem = true;

            //Make item player is holding disappear also
            playerHandT.GetChild(playerInventory.playerItemNum).gameObject.SetActive(false);   //This is less of an abomination, but if it works maybe keep for now?
            playerInventory.playerItemNum = -1;       //Hand is empty again (PlayerInventory)
            playerInventory.droppedItemToRestore = null;     //Won't restore item if drop key is pressed (more of a safeguard really)
        }
        else
        {
            print("Wrong item");        //DEBUG
        }
    }

}
