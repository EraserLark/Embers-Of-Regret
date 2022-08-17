using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotInteractManager : ObjectInteractable   //  ObjectInteractable << Monobehavior
{ 
    //Assign to empty obj, manages the variables holding which Colliders to activate/deactivate as player travels
    //Spot Interact inherits from this

    public static Collider initialDisabledCollider;     //SpotCollider of the Spot the player is currently at (allows Player to interact with things at that area)
    public static Collider currentCollider;             //SpotCollider of Spot that's just been selected, not yet traveled to

    //Starting out, set this 'initialDisabledCollider' to the Lantern's SpotColl, so that way it will turn on when the Player leaves it.
    //Barring they always start at the center platform.
}
