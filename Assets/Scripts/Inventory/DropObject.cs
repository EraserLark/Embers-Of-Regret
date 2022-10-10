using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject originalItemVersion;      //Holds the gameObj for an item source (object of item the player clicks on to "pick up" the item)

    public void StartInvoke(GameObject ogObject)    //Called from PlayerInventory
    {
        Invoke("RestoreDroppedItem", 3f);
        originalItemVersion = ogObject;
    }

    void RestoreDroppedItem()
    {
        originalItemVersion.SetActive(true);
        Destroy(gameObject);    //Destroy instance of item dropped from Player's hand
    }
}
