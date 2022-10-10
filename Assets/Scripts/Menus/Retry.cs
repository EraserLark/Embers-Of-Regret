using UnityEngine;

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
    }
}
