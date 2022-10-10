using UnityEngine;

public class SpotInteract : SpotInteractManager     // SpotInteractManager << ObjectInteractable << Monobehavior
{
    public override void Selected()
    {
        currentCollider = gameObject.GetComponent<Collider>();  //Assigns SpotColl of Spot just clicked on (not yet traveled to)

        if (initialDisabledCollider != null)    //This is the Collider of the Spot the player is leaving from, lets them select it again
        {
            initialDisabledCollider.enabled = true;
        }

        initialDisabledCollider = currentCollider;
        initialDisabledCollider.enabled = false;
    }
}
