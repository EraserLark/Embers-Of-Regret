using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectLockCheck : MonoBehaviour
{
    public SafeHandle safeHandle;

    private void OnTriggerEnter(Collider other)
    {
        safeHandle.numOfCorrectDials++;

        print("Dial Correct. Num of correct dials = " + safeHandle.numOfCorrectDials);      //DEBUG
    }
    private void OnTriggerExit(Collider other)
    {
        safeHandle.numOfCorrectDials--;

        print("Dial Incorrect. Num of correct dials = " + safeHandle.numOfCorrectDials);    //DEBUG
    }
}
