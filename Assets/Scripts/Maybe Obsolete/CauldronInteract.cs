using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInteract : ObjectInteractable
{
    /*
    int solvedCount = 0;

    Renderer brewRenderer;
    Color currentColor;

    //References to the tiny cubes the Player 'holds' after selecting an item
    public GameObject testItemRed;
    public GameObject testItemBlue;

    // Start is called before the first frame update
    void Start()
    {
        brewRenderer = GetComponent<Renderer>();
        //currentColor = Color.magenta;
        //ChangeColor(currentColor);
    }

    //This script is absurdly messy, will most likely want to rework most of the things in here, make stuff cleaner/more efficient
    public override void ItemSelected(int itemNum)
    {
        //base.ItemSelected(itemNum);       //Don't include base functionality, will say you can't use item on it if hand is not empty (but you can use items on this)
        if (itemNum == -1)   //'-1' means the Player is not holding an item (empty hands)
        {
            print("No item to use");
        }

        if (itemNum == 0 && solvedCount == 0)       //itemNum 0 = Red TestItem
        {
            solvedCount++;
            currentColor = Color.blue;
            ChangeColor(currentColor);
            MouseInteract.playerHoldingItem = false;
            testItemRed.SetActive(false);           //The tiny cube obj the Player 'holds' disappears from their hand
            MouseInteract.playerItemNum = -1;       //The player's hand it 'empty' again
        }

        if (itemNum == 1 && solvedCount == 1)
        {
            solvedCount++;
            currentColor = Color.yellow;
            ChangeColor(currentColor);
            MouseInteract.playerHoldingItem = false;
            testItemBlue.SetActive(false);          //The tiny cube obj the Player 'holds' disappears from their hand
            MouseInteract.playerItemNum = -1;       //The player's hand it 'empty' again
        }

        if (solvedCount == 2)
        {
            print("Puzzle Solved!");
            gameObject.SetActive(false);
        }
    }

    void ChangeColor(Color color)       //Add second input for 'Emission color' if want
    {
        brewRenderer.material.SetColor("_Color", color);
        brewRenderer.material.SetColor("_EmissionColor", color);        //Changes emission color
    }
    */
}
