using UnityEngine;

public class NoteManager : ObjectInteractable
{
    public static Transform noteOverlay;
    public GameObject noteBG;
    public GameObject noteText;
    public static int[] noteArray;      //Send in 'noteNum' to reference each individual note

    public GroanAudio mGroanAudio;
    public MonsterFollow2 monsterFollow;

    private void Start()
    {
        noteOverlay = GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(1).gameObject.transform;
        noteBG = noteOverlay.GetChild(0).gameObject;
        noteText = noteOverlay.GetChild(1).gameObject;

        monsterFollow = GameObject.FindGameObjectWithTag("Monster").GetComponent<MonsterFollow2>();
        mGroanAudio = GameObject.FindGameObjectWithTag("Monster").GetComponentInChildren<GroanAudio>();
    }

    public void InteractNote(int noteNum, bool state)
    {
        noteText = noteOverlay.transform.GetChild(noteNum).gameObject;    //noteNum corresponds to "notes" in the child hierarchy for the canvas

        noteOverlay.gameObject.SetActive(state);
        noteText.SetActive(state);
        noteBG.SetActive(state);
        MouseLook.freezeCam = state;

        if(state)
        {
            mGroanAudio.PauseRoar();
            monsterFollow.FreezeMon();
            Time.timeScale = 0f;
        }
        else if(!state)
        {
            mGroanAudio.UnPauseRoar();
            monsterFollow.UnFreezeMon();
            Time.timeScale = 1f;
        }
    }
}
