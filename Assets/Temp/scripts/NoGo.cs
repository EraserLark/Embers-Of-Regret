using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoGo : MonoBehaviour
{
    //reference the text information menu
    public GameObject TextMenuUI;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        TextMenuUI.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        TextMenuUI.SetActive(false);
    }
}
