using UnityEngine;

//Assign to empty obj
public class SpotInteractManager : ObjectInteractable
{ 
    //Manages the variables holding which Colliders to activate/deactivate as player travels

    public static Collider initialDisabledCollider;     //Collider of Spot the player is currently at
    public static Collider currentCollider;             //Collider of Spot that's just been selected, not yet traveled to

    //Starting out, set this 'initialDisabledCollider' to the Lantern's SpotColl, so that way it will turn on when the Player leaves it.
}
