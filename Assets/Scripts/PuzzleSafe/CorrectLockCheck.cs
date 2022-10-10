using UnityEngine;

public class CorrectLockCheck : MonoBehaviour
{
    public SafeHandle safeHandle;

    private void OnTriggerEnter(Collider other)
    {
        safeHandle.numOfCorrectDials++;
    }
    private void OnTriggerExit(Collider other)
    {
        safeHandle.numOfCorrectDials--;
    }
}
