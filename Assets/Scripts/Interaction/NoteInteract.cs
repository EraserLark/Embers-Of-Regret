using UnityEngine;

public class NoteInteract : NoteManager  //NoteManager << ObjectInteractable << Monobehavior
{
    public int noteNum = 0;              //Matched to an array which will bring up corresponding note
    public AudioSource noteSource;

    public override void Awake()
    {
        noteSource = gameObject.GetComponent<AudioSource>();
    }

    public override void Selected()
    {
        base.Selected();

        InteractNote(noteNum, state);
        noteSource.Play();
    }
}
