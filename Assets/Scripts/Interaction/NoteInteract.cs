using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInteract : NoteManager  //  NoteManager << ObjectInteractable << Monobehavior
{
    public int noteNum = 0;     //Different for each note, will tie to an array so that brings up right note
    public AudioSource noteSource;

    public override void Awake()
    {
        //base.Awake();

        noteSource = gameObject.GetComponent<AudioSource>();
    }

    //Unsure of how to fix note softlock rn, too tired to look into it rn as well
    //This doesn't work, but maybe is going in right direction?
    /*
    private void Update()
    {
        if(state)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Selected();
            }
        }
    }
    */

    public override void Selected()
    {
        base.Selected();        //Will change a bool var called 'state' to True if prev. False, or vice versa

        InteractNote(noteNum, state);
        noteSource.Play();
    }
}
