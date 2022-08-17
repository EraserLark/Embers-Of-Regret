using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject skipButton;

    public void Skip()
    {
        fadeOut.SetActive(true);            //Starts fade out
        skipButton.SetActive(false);        //Can't skip anymore
    }
}
