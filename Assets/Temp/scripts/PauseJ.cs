using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseJ : MonoBehaviour
{
    //keep track of if the game is paused
    public static bool GameIsPaused = false;

    //reference to pause menu
    public GameObject pausemenuUI;

    // Update is called once per frame
    void Update()
    {
        //what key to use to pause
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //checking if it's paused or not
            if (GameIsPaused)
            {
                Resume();
                //lock cursor
                Cursor.lockState = CursorLockMode.Locked;
                //make cursor invisible
                Cursor.visible = false;
            }
            else
            {
                Pause();
                //unlock the cursor
                Cursor.lockState = CursorLockMode.None;
                //make cursor visible
                Cursor.visible = true;
            }
        }
    }

    void Resume ()
    {
        //disabling the menu
        pausemenuUI.SetActive(false);
        //resume time
        Time.timeScale = 1f;
        //making it false
        GameIsPaused = false;
    }

    void Pause ()
    {
        //enabling the menu
        pausemenuUI.SetActive(true);
        //freeze time
        Time.timeScale = 0f;
        //making it true
        GameIsPaused = true;
    }
}
