using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    GameObject deathCount;

    public void PlayerQuit()
    {
        //Restarts player's progress in game
        deathCount = GameObject.FindGameObjectWithTag("DeathTrack");
        Destroy(deathCount);

        SceneManager.LoadScene(0);  //Return to main menu
    }
}
