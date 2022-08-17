using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ObjectInteractable  // ObjectInteractable << Monobehavior
{
    public int itemNum;     //DON'T FORGET to set in the Inspector!!   (Defaults to 0)

    public override void Awake()
    {
        base.Awake();   //creates player var, stores the gameObject of the Player
    }

    //When item is clicked on
    public override void Selected()
    {
        //base.Selected();

        if(playerInventory.playerItemNum == -1)     //If player is not already holding an item
        {
            player.GetComponent<PlayerInventory>().HoldItem(itemNum, gameObject);   //Player holds corresponding item in hand
            gameObject.SetActive(false);    //Original item in world disappears
        }
    }
}
