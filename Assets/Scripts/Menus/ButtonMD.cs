using UnityEngine;

public class ButtonMD : MonoBehaviour
{
    private void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
