using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public GameObject deathTrack;

    private void Awake()
    {
        deathTrack = GameObject.FindGameObjectWithTag("DeathTrack");
    }

    public void PlayGame()
    {
        deathTrack.GetComponent<PlayerDeath>().Restart();
        //SceneManager.LoadScene(1);
    }
}
