using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickPlatformScript : MonoBehaviour
{

    // public references
    public Material triggeredMaterial;


    void OnCollisionEnter(Collision boxCollider)
    {
        // This swaps the initial material to the glowing material
        gameObject.GetComponent<Renderer>().material = triggeredMaterial;
    }

}
