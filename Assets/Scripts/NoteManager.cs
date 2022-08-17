using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : ObjectInteractable   //  ObjectInteractable << Monobehavior
{
    public static Transform noteOverlay;
    public GameObject noteBG;
    public GameObject noteText;
    public static int[] noteArray;      //Use to reference 'noteNum' for each individual note, bring up diff message?
                                        //Create another array involving pictures/string and connect to this one to make work?

    public GroanAudio mGroanAudio;
    public MonsterFollow2 monsterFollow;

    private void Start()    //Gets the overlay that is a child in the canvas that is a template for notes
    {
        noteOverlay = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject.transform;
        noteBG = noteOverlay.GetChild(0).gameObject;
        noteText = noteOverlay.GetChild(1).gameObject;

        monsterFollow = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterFollow2>();
        mGroanAudio = GameObject.FindGameObjectWithTag("Monster").GetComponentInChildren<GroanAudio>();

        if (gameObject.transform.childCount > 0)     //Checks if obj has children (otherwise will throw error when running "GetChild")
        {
            //WILL BREAK IF 'NoteOverlay' IS MOVED IN HIERARCHY, need to change the number here if moved!!!
            //noteOverlay = noteText.GetChild(1).gameObject;      //Sets var to store the 'TestNoteOverlay' obj in the Canvas
        }
    }

    public void InteractNote(int noteNum, bool state)        //Use this to find the specific note text/img based off the 'noteNum' (each note will have diff noteNum)
    {
        //print("BringUpNote has been called. Notenum = " + noteNum);     //DEBUG

        noteText = noteOverlay.transform.GetChild(noteNum).gameObject;    //Each noteNum will correspond to the same note in the child hierarchy for the canvas

        noteOverlay.gameObject.SetActive(state);
        noteText.SetActive(state);       //Bring up(T)/Take down(F) the noteOverlay on the UI
        noteBG.SetActive(state);
        MouseLook.freezeCam = state;        //When T camera can move to look around. When F camera is frozen, cannot be rotated w/ mouse input.

        if(state)
        {
            //freeze monster, stop growl audio
            mGroanAudio.PauseRoar();
            monsterFollow.FreezeMon();
            Time.timeScale = 0f;
        }
        else if(!state)
        {
            //Unfreeze
            mGroanAudio.UnPauseRoar();
            monsterFollow.UnFreezeMon();
            Time.timeScale = 1f;
        }
    }

    //Obsolete(?)
    /*
    public void TakeDownNote()
    {
        print("TakeDownNote has been called");
        readingNote = false;
        prevNote.GetComponent<NoteInteract>().state = false;   //To get everything back on the same page, sets the local 'state' var of the note to false again
        noteOverlay.SetActive(false);
    }
    */

}
