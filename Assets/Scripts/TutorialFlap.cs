using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFlap : ObjectInteractable
{
    int numberOfHits = 0;
    public GameObject lanternFlaps;
    public AudioSource lanternSource;
    public AudioClip[] audioClips = new AudioClip[3];

    public override void Selected()
    {
        //base.Selected();
        if(numberOfHits < 2)
        {
            gameObject.transform.Rotate(0f, 0f, 10f, Space.World);
            lanternSource.PlayOneShot(audioClips[numberOfHits]);
            numberOfHits++;
        }
        else
        {
            lanternSource.PlayOneShot(audioClips[numberOfHits]);
            lanternFlaps.SetActive(false);
        }

    }
}
