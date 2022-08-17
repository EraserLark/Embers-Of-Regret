using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject originalItemVersion;      //Passed in through 'StartInvoke' from the PlayerInventory

    public void StartInvoke(GameObject ogObject)    //Called from PlayerInventory
    {
        Invoke("RestoreDroppedItem", 3f);
        originalItemVersion = ogObject;     //Set var in this script to hold the disabled GameObject of the original item that disappeared when first picked up by player
    }

    void RestoreDroppedItem()
    {
        //Add animations and sfx
        originalItemVersion.SetActive(true);    //Set original item in world active again, appears
        Destroy(gameObject);                    //Have fallen version of the mini item from player's hand be deleted
    }
}
