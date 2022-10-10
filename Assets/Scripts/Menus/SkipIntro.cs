using UnityEngine;

public class SkipIntro : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject skipButton;

    public void Skip()
    {
        fadeOut.SetActive(true);
        skipButton.SetActive(false);
    }
}
