using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETactive : MonoBehaviour
{
    public GameObject item;

    //Basic setactive ontriggerenter
    private void OnTriggerEnter(Collider other)
    {
        item.SetActive(true);
    }
}
