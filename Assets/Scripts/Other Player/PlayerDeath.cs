using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public int jumpscareLength;

    public bool redIsUnlocked;
    public bool greenIsUnlocked;
    public bool purpleIsUnlocked;

    LockBase lockBase;
    BookTrack bookTrack;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform);
        lockBase = GameObject.FindGameObjectWithTag("LockBase").GetComponent<LockBase>();
        bookTrack = GameObject.FindGameObjectWithTag("Bookshelf").GetComponent<BookTrack>();    //Ref to book tracking script for bookshelf puzzle, use for reseting
    }

    public void GameOverCountdown(float jsLength)
    {
        Invoke("GameOver", jsLength);


        lockBase.redUnlocked = redIsUnlocked;
        lockBase.greenUnlocked = greenIsUnlocked;
        lockBase.purpleUnlocked = purpleIsUnlocked;

    }

    public void GameOver()
    {
        //print("You died!");         //DEBUG
        //Drop Item
        //Jumpscare plays, player 'dies'
        //Menu pops up, Retry?
        MouseLook.freezeCam = true;
        Cursor.lockState = CursorLockMode.None;
        bookTrack.ResetBooks();     //Reset bookshelf puzzle
        MonsterFollow2.candleLit = false;


        //Respawn Player
        SceneManager.LoadScene(10);      //Go to game over screen
        //Restart();
    }

    public void Restart()
    {
        //RED KEY USED FIRST
        if (redIsUnlocked)
        {
            if(greenIsUnlocked)
            {
                SceneManager.LoadScene(7);  //Red + Green
            }
            else if(purpleIsUnlocked)
            {
                SceneManager.LoadScene(6);  //Red + Purple
            }
            else
            {
                SceneManager.LoadScene(3);  //Only Red
            }
        }

        //GREEN KEY USED FIRST
        if (greenIsUnlocked)
        {
            if (redIsUnlocked)
            {
                SceneManager.LoadScene(7);  //Red + Green
            }
            else if (purpleIsUnlocked)
            {
                SceneManager.LoadScene(8);  //Purple + Green
            }
            else
            {
                SceneManager.LoadScene(4);  //Only Green
            }
        }

        //PURPLE KEY USED FIRST
        if (purpleIsUnlocked)
        {
            if (redIsUnlocked)
            {
                SceneManager.LoadScene(6);  //Red + Purple
            }
            else if (greenIsUnlocked)
            {
                SceneManager.LoadScene(8);  //Purple + Green
            }
            else
            {
                SceneManager.LoadScene(5);  //Only Purple
            }
        }
        //NO KEYS USED YET
        else if (!redIsUnlocked && !greenIsUnlocked && !purpleIsUnlocked)
        {
            SceneManager.LoadScene(2);  //No Keys
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);   //Restarts current scene
        print("Red" + redIsUnlocked + "Green" + greenIsUnlocked + "Purple" + purpleIsUnlocked);     //DEBUG
    }
}
