using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotInteract : SpotInteractManager     // SpotInteractManager << ObjectInteractable << Monobehavior
{
    //Would be nice to do this after the Player finishes travelling, reaches the Spot they selected. That way they can't interact with things at that spot before getting there (intentionally or accidentally)
    //For now though, this should work ok...
    public override void Selected()
    {
        base.Selected();    //Runs the code in "ObjectInteractable" first (the boolean has no influence on code/values here though, rn)

        currentCollider = gameObject.GetComponent<Collider>();  //Assigns SpotColl of Spot just clicked on (not yet traveled to)

        if (initialDisabledCollider != null)    //If there is a Coll stored in this var, set it to true (This is the SpotColl of the Spot the player is leaving from, lets them select it again to travel to)
        {
            initialDisabledCollider.enabled = true;
        }

        initialDisabledCollider = currentCollider;  //Set SpotColl of the spot just clicked on to this var
        initialDisabledCollider.enabled = false;    //Then disable this SpotColl (one player is traveling to, so can interact with things at that Spot)
    }
}
