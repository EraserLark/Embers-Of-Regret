using UnityEngine;

public class ActivateFinalFade : MonoBehaviour
{
    public GameObject finalFade;

    void Start()
    {
        finalFade.SetActive(true);
    }
}
