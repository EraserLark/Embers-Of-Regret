using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enables the Player to use the Mouse to look around
public class MouseLook : MonoBehaviour
{
    //Tutorial:
    //https://youtu.be/_QajrabyTJc

    public float mouseSensitivity = 100f;   //Determines speed at which camera will turn
                                            //100f = default, I think 300f is better though

    public Transform playerBody;    //Reference to First Person Player object
                                    //I think the Character Controller component is what allows this code to work vs with just camera

    float xRotation = 0f;   //Stores mouseY, for rotating around X axis to look up/down

    public static bool freezeCam;   //When T camera can move to look around. When F camera is frozen, cannot be rotated w/ mouse input.

    private void Start()
    {
        freezeCam = false;      //Do this to avoid softlock if you die while reading a note or something
        Cursor.lockState = CursorLockMode.Locked;   //Hides & Locks mouse cursor
    }

    void Update()
    {
        if (!freezeCam)  //Camera can look around if game is not paused
        {
            Cursor.lockState = CursorLockMode.Locked;   //Hides & Locks mouse cursor

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;    //Get Input on their Player's mouse movement - X axis
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;    //Get Input on their Player's mouse movement - Y axis
                                                                                            //Multiply by mouseSensitivity make camera turn at desired speed
                                                                                            //Multiply by Time.deltaTime to rotate independent of framerate (Since inside Update function)

            xRotation -= mouseY;    //Decrease xRotation based on mouseY (Rotation is inverted if +=)
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);      //Clamping (Setting limits for) vertical rotation
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      //Applies rotation around X-axis (Up/Down), don't want to rotate other directions

            playerBody.Rotate(Vector3.up * mouseX);     //Rotate entire body of Player (X axis only)
        }
    }
}
