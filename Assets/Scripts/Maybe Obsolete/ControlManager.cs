using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    /*
    public static bool readingNote = false; //Var that tells game to stop cam movement when reading notes (Camera Locked)
    public static bool paused = false;      //Var that tells the game to pause when true (See below + Free Mouse, Movement Stopped)

    public static bool gamePause = false;   //For freezing camera movement and raycast input (for Pausing)

    //readingNote stops cam movement, still permits raycasts
    //paused stops cam movement and stops raycasts
    //So: gamePause occurs if 'readingNote' or 'paused' = true, so it stops cam movement
    //'paused' stops raycasting specifically

    //So so: I want the cam movement to freeze when reading notes, raycasts to still work to exit notes. Not having game pause anymore, so want to
    //get rid of 'paused' and keep 'gamePause'.
    //Have reading note be a public static bool on the Player

    public MonsterFollow2 monsterFollow;

    /*
    private void Start()        //For tutorial, don't need for final game
    {
        paused = true;
        Time.timeScale = 0f;                //Stops Player movement
        monsterFollow.PauseMonster();       //Stops Monster movement
    }
    

    // Update is called once per frame
    void Update()
    {
        //PROBLEM: The 'paused' var changes for each obj in scene that contains a scrpt that inherits from this (So 14 objs = paused changes 14 times)
        //Duplicate an obj like the 'TestNote' and you'll see this number goes up.

        /*
        if (Input.GetKeyDown(KeyCode.P))        //Press P to pause game
        {
            if (paused == false)    
            {
                paused = true;
                Time.timeScale = 0f;                //Stops Player movement
                monsterFollow.PauseMonster();       //Stops Monster movement
                //print("P pressed " + paused);       //DEBUG
            }
            else if (paused == true)
            {
                paused = false;                     
                Time.timeScale = 1f;                //Starts Player movement
                monsterFollow.ResumeMonster();      //Starts Monster movement   (Prev set to 'TimerStart()')
                //print("P pressed " + paused);       //DEBUG
            }
        }
        */
        /*
        if (readingNote == true || paused == true)   //If either Var is true (so should be able to unpause while reading a note and things stay locked?)
        {
            gamePause = true;
            //print("gamePause is " + gamePause);     //DEBUG
        }
        else
        {
            gamePause = false;
        }
        
    }
    */
}
