using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterActive : MonoBehaviour
{
    //reference the text information menu
    public GameObject section;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        section.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        section.SetActive(false);
    }
}
