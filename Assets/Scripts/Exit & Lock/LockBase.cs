using UnityEngine;

public class LockBase : MonoBehaviour
{
    public PlayerDeath playerDeath;
    public InitialExit initialExit;

    public bool firstPlay;

    public bool redUnlocked = false;
    public bool greenUnlocked = false;
    public bool purpleUnlocked = false;

    public bool allUnlocked = false;

    public MonsterFollow2 monsterFollow2;

    private void Awake()
    {
        playerDeath = GameObject.FindGameObjectWithTag("DeathTrack").GetComponent<PlayerDeath>();
        monsterFollow2 = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterFollow2>();
    }

    private void Start()
    {
        if(firstPlay)
        {
            gameObject.SetActive(false);    //Lock will not have appeared yet in first playthrough
        }
    }

    public void Unlocked(string name)
    {
        switch (name)
        {
            case "LockRed":
                redUnlocked = true;
                playerDeath.redIsUnlocked = true;
                monsterFollow2.IncreaseSpeed();
                break;

            case "LockGreen":
                greenUnlocked = true;
                playerDeath.greenIsUnlocked = true;
                monsterFollow2.IncreaseSpeed();
                break;

            case "LockPurple":
                purpleUnlocked = true;
                playerDeath.purpleIsUnlocked = true;
                monsterFollow2.IncreaseSpeed();
                break;
        }

        if(redUnlocked && greenUnlocked && purpleUnlocked)
        {
            initialExit.AllUnlocked();  //Changes door tag so that hand appears when mouse over again
            allUnlocked = true;
        }
    }
}
