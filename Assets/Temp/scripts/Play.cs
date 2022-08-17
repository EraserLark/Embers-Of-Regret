using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void PlayGame ()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(11);  //Initial Play try
    }
}
