using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBase : MonoBehaviour
{
    //public PlayerDeath[] playerDeath;
    //public GameObject[] playerDeathArray;
    //public List<GameObject> playerDeathList;
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
        //playerDeathArray = GameObject.FindGameObjectsWithTag("DeathTrack");   //Keeping JIC everything breaks with new system for some reason (:
        playerDeath = GameObject.FindGameObjectWithTag("DeathTrack").GetComponent<PlayerDeath>();
        monsterFollow2 = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterFollow2>();
    }

    private void Start()
    {
        if(firstPlay)
        {
            gameObject.SetActive(false);
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
            /*
            foreach(GameObject playerDeath in playerDeathArray)
            {
                playerDeath.GetComponent<PlayerDeath>().redIsUnlocked = true;
            }
            */

            case "LockGreen":
                greenUnlocked = true;
                playerDeath.greenIsUnlocked = true;
                monsterFollow2.IncreaseSpeed();
                break;

                /*
                foreach (GameObject playerDeath in playerDeathArray)
                {
                    playerDeath.GetComponent<PlayerDeath>().greenIsUnlocked = true;
                }
                break;
                */

            case "LockPurple":
                purpleUnlocked = true;
                playerDeath.purpleIsUnlocked = true;
                monsterFollow2.IncreaseSpeed();
                break;

                /*
                foreach (GameObject playerDeath in playerDeathArray)
                {
                    playerDeath.GetComponent<PlayerDeath>().purpleIsUnlocked = true;
                }
                break;
                */
        }

        if(redUnlocked && greenUnlocked && purpleUnlocked)
        {
            initialExit.AllUnlocked();  //Changes door tag so that hand appears when mouse over again
            allUnlocked = true;         //Could probably set in Initial Exit script with this new funcrion above, but don't want to risk breaking too much rn
        }
    }
}
