using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    //reference the text information menu
    public GameObject selection;
    public GameObject selection2;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        selection.SetActive(false);
        //selection2.SetActive(false);
    }
}
