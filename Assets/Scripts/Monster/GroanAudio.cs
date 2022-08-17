using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroanAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips = new AudioClip[0];   //Currently set to 16 in Inspector (as of rn probably won't change, unless adding more monster sfx)

    int randomClip;             //Holds random number from length of array, tells audio source which clip to play
    int randomDelayNum = 5;     //Set for initial Invoke rn, will most likely change later

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        NewRandomNumbers();
        Invoke("Roar", randomDelayNum);     //Probably will want to change this, start the Roar cycle once the player finished lantern tutorial?
    }

    void Roar()
    {
        NewRandomNumbers();
        audioSource.PlayOneShot(audioClips[randomClip]);
        Invoke("Roar", randomDelayNum);
    }

    void NewRandomNumbers()
    {
        randomClip = Random.Range(0, audioClips.Length);
        randomDelayNum = Random.Range((int) audioClips[randomClip].length, 15); //Might break, unsure if '(int)' will always work right w/ this?
                                                                                //Will delay the next 'Roar' until at minimum, the general runtime of the prev clip has finished
    }

    //For use when reading notes, pausing monster
    public void PauseRoar()
    {
        //CancelInvoke("Roar");
        audioSource.volume = 0f;
    }

    public void  UnPauseRoar()
    {
        audioSource.volume = 1f;
    }
}
