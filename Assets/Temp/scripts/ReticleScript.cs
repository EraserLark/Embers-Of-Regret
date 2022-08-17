using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Reports that the ReticleScript is online
        Debug.Log("ReticleScript is online");

        // Locks the cursor to the centre of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // Makes the cursor invisible
        Cursor.visible = false;
    }
}
