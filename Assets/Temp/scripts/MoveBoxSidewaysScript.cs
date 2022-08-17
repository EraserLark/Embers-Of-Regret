using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoxSidewaysScript : MonoBehaviour
{
    public Transform putBoxHere;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger triggered");

        other.transform.position = putBoxHere.transform.position;
    }
}
