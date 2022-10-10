using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float xRotation = 0f;
    public static bool freezeCam;

    public Transform playerBody;

    private void Start()
    {
        freezeCam = false;      //Avoids softlock if you die while reading a note
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!freezeCam)
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;    
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;    

            xRotation -= mouseY;    //Decrease xRotation based on mouseY (Rotation is inverted if +=)
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);      //Setting limits for vertical rotation
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);      //Applies rotation around X-axis (Up/Down), don't want to rotate other directions

            playerBody.Rotate(Vector3.up * mouseX);     //Rotate entire body of Player (X axis only)
        }
    }
}
