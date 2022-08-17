using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportBeamScript : MonoBehaviour
{
    // Public references
    public GameObject moveZone;
    public Transform endPoint;

    // Public variables
    public float speed;
    public bool beamOn = false;

    // Private variables
    Renderer rendComponent;                         // Empty container for our renderer component


    void Start()
    {
        // Fill the renderer 'container'
        rendComponent = GetComponent<Renderer>();   
    }



    private void OnTriggerStay(Collider other)
    {

        if (beamOn == true)
        {
            // If the triggering object has a Rigidbody component attached to it..
            if (other.attachedRigidbody)
            {
                // .. disable 'Use Gravity'
                other.attachedRigidbody.useGravity = false;
            }

            // This zeroes the object's velocity
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;

            // This moves the object towards the provided location
            other.transform.position = Vector3.MoveTowards(other.transform.position, endPoint.position, speed * Time.deltaTime);
        }
    }

    // When the other object leaves the beam
    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            // Restore gravity
            other.attachedRigidbody.useGravity = true;
        }
    }

}
