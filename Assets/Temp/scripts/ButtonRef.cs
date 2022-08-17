using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRef : MonoBehaviour
{
    // Public references:
    [Header("REFERENCES")]
    public GameObject targetBoxMaker01;
    public GameObject targetBoxMaker02;
    public GameObject targetBoxMaker03;


    // Public variables:
    [Header("BUTTON COLOURS")]
    public Material makeBoxesMaterial;
    public Material stopBoxesMaterial;

    // private variables:
    bool makingBoxes = true;


    // This describes what to do when the mouse is clicked
    private void OnMouseDown()
    {
        // Plays the audio clip
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        // This will find the 'toggleMakeBoxes' method in the BoxMakerScript and run it
        targetBoxMaker01.GetComponent<BoxMakerScript>().toggleMakeBoxes();
        targetBoxMaker02.GetComponent<BoxMakerScript>().toggleMakeBoxes();
        targetBoxMaker03.GetComponent<BoxMakerScript>().toggleMakeBoxes();

        if (makingBoxes == true)
        {
            // This swaps the button material to red
            gameObject.GetComponent<Renderer>().material = stopBoxesMaterial;

            makingBoxes = false;
        }

        else
        {
            // This swaps the button material to green
            gameObject.GetComponent<Renderer>().material = makeBoxesMaterial;

            makingBoxes = true;
        }
    }
}
