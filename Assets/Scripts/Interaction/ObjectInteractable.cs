using UnityEngine;

public class ObjectInteractable : MonoBehaviour
{
    public bool state = false;
    public GameObject player;
    public bool itemInteractable = false;       //Set true for objs that will have item interactability
    public PlayerInventory playerInventory;

    public virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    public virtual void Selected()
    {
        state = !state;
    }

    public virtual void ItemSelected()       //Right click
    {
        if (!itemInteractable)
        {
            print("You can't use an item on this!");    //Overload this in objs where you want an item to work! (Remove base.ItemSelected!)
        }
    }
}
