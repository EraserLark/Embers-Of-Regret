using UnityEngine;

public class GroanAudio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] audioClips = new AudioClip[0];   //Set to 16 in Inspector

    int randomClipNum;          //Holds random number between 0 and 15
    int randomDelayNum = 5;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        NewRandomNumbers();
        Invoke("Roar", randomDelayNum);
    }

    void Roar()
    {
        NewRandomNumbers();
        audioSource.PlayOneShot(audioClips[randomClipNum]);
        Invoke("Roar", randomDelayNum);
    }

    void NewRandomNumbers()
    {
        randomClipNum = Random.Range(0, audioClips.Length);
        //Delays the next 'Roar' at least until the runtime of the prev clip has finished
        randomDelayNum = Random.Range((int) audioClips[randomClipNum].length, 15);
    }

    public void PauseRoar()
    {
        audioSource.volume = 0f;
    }

    public void UnPauseRoar()
    {
        audioSource.volume = 1f;
    }
}
