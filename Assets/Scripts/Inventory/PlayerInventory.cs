using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int playerItemNum;
    public GameObject playerHand;               
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
        if(playerItemNum == -1)  //If player's hand is empty
        {
            playerItemNum = itemNum;
            droppedItemToRestore = itemToRestore;
            playerHand.transform.GetChild(playerItemNum).gameObject.SetActive(true);
            playerSource.PlayOneShot(grabItem);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(playerItemNum != -1)     //If player is holding an item
            {
                DropItem();
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
