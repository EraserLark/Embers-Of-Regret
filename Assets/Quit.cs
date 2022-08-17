using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    GameObject deathCount;

    public void PlayerQuit()
    {
        //Do this to restart player's progress in game
        deathCount = GameObject.FindGameObjectWithTag("DeathTrack");
        Destroy(deathCount);

        SceneManager.LoadScene(0);  //Return to main menu
    }
}
