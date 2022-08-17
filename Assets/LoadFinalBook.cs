using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFinalBook : MonoBehaviour
{
    public GameObject outroP2;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        //print(Cursor.lockState + "Start");        //DEBUG
    }

    public void loadOutroP2()
    {
        //print("Clicked!");
        outroP2.SetActive(true);
    }
}
