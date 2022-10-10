using UnityEngine;

public class ItemInteractable : ObjectInteractable
{
    public bool correctItem = false;     //If true, run specific functions in child scripts
    public int keyItem = 0;      //Set in inspector, is the itemNum for the item that correctly interacts with this obj, playersItemNum must be equal to this in order to accept
    public Transform playerHandT;

    public override void Awake()
    {
        base.Awake();

        playerHandT = player.transform.GetChild(0).transform.GetChild(0).transform;
    }

    public override void ItemSelected()
    {
        base.ItemSelected();

        if (playerInventory.playerItemNum == keyItem)
        {
            correctItem = true;

            //Item player is holding disappears
            playerHandT.GetChild(playerInventory.playerItemNum).gameObject.SetActive(false);
            playerInventory.playerItemNum = -1;
            playerInventory.droppedItemToRestore = null;
        }
    }
}
