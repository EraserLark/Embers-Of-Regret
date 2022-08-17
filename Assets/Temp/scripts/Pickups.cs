using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    //reference the text information menu
   // public GameObject basic;

    public GameObject original;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
       // basic.SetActive(true);
        Destroy(original.gameObject);
    }
}
