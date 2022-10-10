using UnityEngine;

public class LoadFinalBook : MonoBehaviour
{
    public GameObject outroP2;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void loadOutroP2()
    {
        outroP2.SetActive(true);
    }
}
