public class Item : ObjectInteractable  // ObjectInteractable << Monobehavior
{
    public int itemNum;     //Set in inspector (Defaults to 0)

    public override void Awake()
    {
        base.Awake();   //creates player var, stores the gameObject of the Player
    }

    public override void Selected()
    {
        if(playerInventory.playerItemNum == -1)     //If player is not already holding an item
        {
            player.GetComponent<PlayerInventory>().HoldItem(itemNum, gameObject);
            gameObject.SetActive(false);
        }
    }
}
